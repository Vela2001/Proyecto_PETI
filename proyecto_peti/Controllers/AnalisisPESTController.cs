using proyecto_peti.Models;
using proyecto_peti.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_peti.Controllers
{
    public class AnalisisPESTController : Controller
    {
        private Modelo db = new Modelo();


        [HttpGet]
        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var entidad = db.AnalisisPEST.FirstOrDefault(a => a.PlanId == planId);

            var model = new AnalisisPestViewModel();

            if (entidad != null)
            {
                model.Id = entidad.Id;
                model.PlanId = entidad.PlanId;

                model.Pregunta1 = entidad.Pregunta1;
                model.Pregunta2 = entidad.Pregunta2;
                model.Pregunta3 = entidad.Pregunta3;
                model.Pregunta4 = entidad.Pregunta4;
                model.Pregunta5 = entidad.Pregunta5;
                model.Pregunta6 = entidad.Pregunta6;
                model.Pregunta7 = entidad.Pregunta7;
                model.Pregunta8 = entidad.Pregunta8;
                model.Pregunta9 = entidad.Pregunta9;
                model.Pregunta10 = entidad.Pregunta10;
                model.Pregunta11 = entidad.Pregunta11;
                model.Pregunta12 = entidad.Pregunta12;
                model.Pregunta13 = entidad.Pregunta13;
                model.Pregunta14 = entidad.Pregunta14;
                model.Pregunta15 = entidad.Pregunta15;
                model.Pregunta16 = entidad.Pregunta16;
                model.Pregunta17 = entidad.Pregunta17;
                model.Pregunta18 = entidad.Pregunta18;
                model.Pregunta19 = entidad.Pregunta19;
                model.Pregunta20 = entidad.Pregunta20;
                model.Pregunta21 = entidad.Pregunta21;
                model.Pregunta22 = entidad.Pregunta22;
                model.Pregunta23 = entidad.Pregunta23;
                model.Pregunta24 = entidad.Pregunta24;
                model.Pregunta25 = entidad.Pregunta25;

                model.Oportunidad3 = entidad.Oportunidad3;
                model.Oportunidad4 = entidad.Oportunidad4;
                model.Amenaza3 = entidad.Amenaza3;
                model.Amenaza4 = entidad.Amenaza4;
            }
            else
            {
                model.PlanId = planId;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AnalisisPestViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            model.PlanId = (int)Session["PlanId"];

            var entidad = db.AnalisisPEST.FirstOrDefault(a => a.PlanId == model.PlanId);

            if (entidad == null)
            {
                entidad = new AnalisisPEST
                {
                    PlanId = model.PlanId
                };

                db.AnalisisPEST.Add(entidad);
            }

            // Asignación de valores
            entidad.Pregunta1 = model.Pregunta1;
            entidad.Pregunta2 = model.Pregunta2;
            entidad.Pregunta3 = model.Pregunta3;
            entidad.Pregunta4 = model.Pregunta4;
            entidad.Pregunta5 = model.Pregunta5;
            entidad.Pregunta6 = model.Pregunta6;
            entidad.Pregunta7 = model.Pregunta7;
            entidad.Pregunta8 = model.Pregunta8;
            entidad.Pregunta9 = model.Pregunta9;
            entidad.Pregunta10 = model.Pregunta10;
            entidad.Pregunta11 = model.Pregunta11;
            entidad.Pregunta12 = model.Pregunta12;
            entidad.Pregunta13 = model.Pregunta13;
            entidad.Pregunta14 = model.Pregunta14;
            entidad.Pregunta15 = model.Pregunta15;
            entidad.Pregunta16 = model.Pregunta16;
            entidad.Pregunta17 = model.Pregunta17;
            entidad.Pregunta18 = model.Pregunta18;
            entidad.Pregunta19 = model.Pregunta19;
            entidad.Pregunta20 = model.Pregunta20;
            entidad.Pregunta21 = model.Pregunta21;
            entidad.Pregunta22 = model.Pregunta22;
            entidad.Pregunta23 = model.Pregunta23;
            entidad.Pregunta24 = model.Pregunta24;
            entidad.Pregunta25 = model.Pregunta25;

            entidad.Oportunidad3 = model.Oportunidad3;
            entidad.Oportunidad4 = model.Oportunidad4;
            entidad.Amenaza3 = model.Amenaza3;
            entidad.Amenaza4 = model.Amenaza4;

            db.SaveChanges();


            return RedirectToAction("Index");
        }


    }
}