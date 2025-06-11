using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using proyecto_peti.Models;

namespace proyecto_peti.Controllers
{
    public class ObjetivosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Objetivos
        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var objetivos = db.ObjetivosEstrategicos
                              .Where(o => o.PlanId == planId)
                              .OrderBy(o => o.Id)
                              .ToList();

            while (objetivos.Count < 3)
            {
                objetivos.Add(new ObjetivosEstrategicos());
            }

            return View(objetivos);
        }

        [HttpPost]
        public ActionResult Guardar(List<ObjetivosEstrategicos> model)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];
            string comentario = Request.Form["UENComentario"];

            var existentes = db.ObjetivosEstrategicos.Where(o => o.PlanId == planId).ToList();


            db.ObjetivosEstrategicos.RemoveRange(existentes);
            db.SaveChanges();

            foreach (var objetivo in model)
            {
                if (!string.IsNullOrWhiteSpace(objetivo.Objetivo))
                {
                    objetivo.PlanId = planId;
                    objetivo.CreatedAt = DateTime.Now;
                    objetivo.UENComentario = comentario;
                    db.ObjetivosEstrategicos.Add(objetivo);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index", "AnalisisFODA"); // o la siguiente vista que tengas
        }
    }
}