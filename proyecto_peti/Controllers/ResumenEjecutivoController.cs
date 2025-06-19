using proyecto_peti.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_peti.Controllers
{
    public class ResumenEjecutivoController : Controller
    {
        // GET: ResumenEjecutivo
        public ActionResult Index()
        {
            // Inicializar el modelo con valores por defecto
            var model = new Resumen
            {
                Id = 0,
                PlanId = 0,
                FechaElaboracion = DateTime.Now,
                Objetivos = new List<ObjetivoEstrategicoItem>
                {
                    new ObjetivoEstrategicoItem(),
                    new ObjetivoEstrategicoItem(),
                    new ObjetivoEstrategicoItem()
                }
            };

            return View(model);
        }
        // POST: ResumenEjecutivo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Resumen model, HttpPostedFileBase LogoFile)
        {
            try
            {
                // Validar el modelo
                if (ModelState.IsValid)
                {
                    // Manejar la subida del logo si hay archivo
                    if (LogoFile != null && LogoFile.ContentLength > 0)
                    {
                        // Validar tipo de archivo
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var fileExtension = System.IO.Path.GetExtension(LogoFile.FileName).ToLower();

                        if (Array.IndexOf(allowedExtensions, fileExtension) >= 0)
                        {
                            // Generar nombre único para el archivo
                            var fileName = Guid.NewGuid().ToString() + fileExtension;
                            var uploadPath = Server.MapPath("~/Content/Uploads/Logos/");

                            // Crear directorio si no existe
                            if (!System.IO.Directory.Exists(uploadPath))
                            {
                                System.IO.Directory.CreateDirectory(uploadPath);
                            }

                            var filePath = System.IO.Path.Combine(uploadPath, fileName);
                            LogoFile.SaveAs(filePath);

                            // Guardar la ruta relativa en el modelo
                            model.LogoPath = "~/Content/Uploads/Logos/" + fileName;
                        }
                        else
                        {
                            ModelState.AddModelError("LogoFile", "Formato de archivo no válido. Use JPG, PNG o GIF.");
                        }
                    }

                    // Aquí puedes guardar el modelo en la base de datos
                    // Por ejemplo: _repository.Save(model);

                    // Redirigir a la siguiente página o mostrar mensaje de éxito
                    TempData["Success"] = "Resumen ejecutivo guardado correctamente.";
                    return RedirectToAction("Index"); // o a la siguiente vista
                }
            }
            catch (Exception ex)
            {
                // Manejar errores
                ModelState.AddModelError("", "Error al guardar: " + ex.Message);
            }

            // Si llegamos aquí, algo salió mal. Asegurar que el modelo tenga la estructura correcta
            if (model.Objetivos == null || model.Objetivos.Count == 0)
            {
                model.Objetivos = new List<ObjetivoEstrategicoItem>
                {
                    new ObjetivoEstrategicoItem(),
                    new ObjetivoEstrategicoItem(),
                    new ObjetivoEstrategicoItem()
                };
            }

            return View(model);
        }

        // Método auxiliar para cargar un modelo existente (si editas)
        public ActionResult Edit(int id)
        {
            // Aquí cargarías el modelo desde la base de datos
            // var model = _repository.GetById(id);

            // Por ahora, crear un modelo de ejemplo
            var model = new Resumen
            {
                Id = id,
                PlanId = 1,
                NombreEmpresa = "Empresa de Ejemplo",
                FechaElaboracion = DateTime.Now.AddDays(-30),
                Promotores = "Juan Pérez, María García",
                Mision = "Nuestra misión es...",
                Vision = "Nuestra visión es...",
                Valor1 = "Integridad",
                Valor2 = "Excelencia",
                Valor3 = "Innovación",
                Valor4 = "Compromiso",
                Valor5 = "Responsabilidad",
                UnidadesEstrategicas = "Marketing, Ventas, Producción",
                Objetivos = new List<ObjetivoEstrategicoItem>
                {
                    new ObjetivoEstrategicoItem
                    {
                        ObjetivoGeneral = "Incrementar la participación en el mercado",
                        ObjetivoEspecifico1 = "Aumentar ventas en 20%",
                        ObjetivoEspecifico2 = "Expandir a 3 nuevas ciudades"
                    },
                    new ObjetivoEstrategicoItem
                    {
                        ObjetivoGeneral = "Mejorar la eficiencia operativa",
                        ObjetivoEspecifico1 = "Reducir costos en 15%",
                        ObjetivoEspecifico2 = "Automatizar procesos clave"
                    },
                    new ObjetivoEstrategicoItem
                    {
                        ObjetivoGeneral = "Fortalecer el capital humano",
                        ObjetivoEspecifico1 = "Capacitar al 100% del personal",
                        ObjetivoEspecifico2 = "Implementar sistema de evaluación"
                    }
                },
                FodaDebilidades = "Limitada presencia digital, personal poco capacitado",
                FodaAmenazas = "Competencia agresiva, cambios regulatorios",
                FodaFortalezas = "Buena reputación, productos de calidad",
                FodaOportunidades = "Mercados emergentes, nuevas tecnologías",
                IdentificacionEstrategia = "Estrategia de diferenciación basada en calidad y servicio",
                Conclusiones = "El plan estratégico plantea un crecimiento sostenible..."
            };

            return View("Index", model);
        }
        public ActionResult Ultimo()
        {
            return View();
        }
    }
}