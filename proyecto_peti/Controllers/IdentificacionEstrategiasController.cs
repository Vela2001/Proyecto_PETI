using System;
using System.Linq;
using System.Web.Mvc;
using proyecto_peti.Models;

namespace proyecto_peti.Controllers
{
    public class IdentificacionEstrategiasController : Controller
    {
        private Modelo db = new Modelo();

        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];
            var estrategia = db.IdentificacionEstrategias.FirstOrDefault(e => e.PlanId == planId);
            if (estrategia == null)
                estrategia = new IdentificacionEstrategias { PlanId = planId };

            return View(estrategia);
        }

        [HttpPost]
        public ActionResult Index(IdentificacionEstrategias model)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];
            var existente = db.IdentificacionEstrategias.FirstOrDefault(e => e.PlanId == planId);

            if (existente != null)
            {
                db.Entry(existente).CurrentValues.SetValues(model);
                existente.UpdatedAt = DateTime.Now;
            }
            else
            {
                model.CreatedAt = DateTime.Now;
                db.IdentificacionEstrategias.Add(model);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "MatrizCAME");
        }
    }
}
