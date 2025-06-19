using System;
using System.Linq;
using System.Web.Mvc;
using proyecto_peti.Models;

namespace proyecto_peti.Controllers
{
    public class MatrizCAMEController : Controller
    {
        private Modelo db = new Modelo();

        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];
            var modelo = db.MatrizCAME.FirstOrDefault(x => x.PlanId == planId);

            if (modelo == null)
                modelo = new MatrizCAME { PlanId = planId };

            return View(modelo);
        }

        [HttpPost]
        public ActionResult GuardarMatrizCAME(FormCollection form)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            // Verifica si ya existe
            var entidad = db.MatrizCAME.FirstOrDefault(m => m.PlanId == planId);
            if (entidad == null)
            {
                entidad = new MatrizCAME { PlanId = planId };
                db.MatrizCAME.Add(entidad);
            }

            // Asignar valores de los campos del formulario
            entidad.Corregir1 = form["Corregir1"];
            entidad.Corregir2 = form["Corregir2"];
            entidad.Corregir3 = form["Corregir3"];
            entidad.Corregir4 = form["Corregir4"];

            entidad.Afrontar1 = form["Afrontar1"];
            entidad.Afrontar2 = form["Afrontar2"];
            entidad.Afrontar3 = form["Afrontar3"];
            entidad.Afrontar4 = form["Afrontar4"];

            entidad.Mantener1 = form["Mantener1"];
            entidad.Mantener2 = form["Mantener2"];
            entidad.Mantener3 = form["Mantener3"];
            entidad.Mantener4 = form["Mantener4"];

            entidad.Explotar1 = form["Explotar1"];
            entidad.Explotar2 = form["Explotar2"];
            entidad.Explotar3 = form["Explotar3"];
            entidad.Explotar4 = form["Explotar4"];

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
