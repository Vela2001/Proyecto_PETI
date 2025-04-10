using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using proyecto_peti.Models;

namespace proyecto_peti.Controllers
{
    public class AccountController : Controller
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        // GET: Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Password FROM Users WHERE Username=@Username";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", model.Username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashedPassword = reader["Password"].ToString();
                                if (VerifyPassword(model.Password, hashedPassword))
                                {
                                    FormsAuthentication.SetAuthCookie(model.Username, false);
                                    return RedirectToLocal(returnUrl);
                                }
                            }
                        }
                    }
                }

                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al iniciar sesión: " + ex.Message);
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Verificar si el usuario ya existe
                    string checkQuery = "SELECT COUNT(1) FROM Users WHERE Username=@Username";
                    using (var checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", model.Username);
                        int exists = (int)checkCmd.ExecuteScalar();

                        if (exists > 0)
                        {
                            ModelState.AddModelError("Username", "El nombre de usuario ya está en uso");
                            return View(model);
                        }
                    }

                    // Insertar nuevo usuario
                    string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                    using (var insertCmd = new SqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", model.Username);
                        insertCmd.Parameters.AddWithValue("@Password", HashPassword(model.Password));

                        insertCmd.ExecuteNonQuery();
                    }
                }

                TempData["SuccessMessage"] = "Registro exitoso. Por favor inicie sesión.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar: " + ex.Message);
                return View(model);
            }
        }

        private string HashPassword(string password)
        {
            // Usamos PBKDF2 con HMAC-SHA256 para mayor seguridad
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 32, 10000))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] hash = deriveBytes.GetBytes(32);

                byte[] hashBytes = new byte[64];
                Array.Copy(salt, 0, hashBytes, 0, 32);
                Array.Copy(hash, 0, hashBytes, 32, 32);

                return Convert.ToBase64String(hashBytes);
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[32];
            Array.Copy(hashBytes, 0, salt, 0, 32);

            using (var deriveBytes = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
            {
                byte[] newHash = deriveBytes.GetBytes(32);

                for (int i = 0; i < 32; i++)
                {
                    if (hashBytes[i + 32] != newHash[i])
                        return false;
                }
            }

            return true;
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}