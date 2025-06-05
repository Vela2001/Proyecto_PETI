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
        public ActionResult Index(MatrizCAME model)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];
            var existente = db.MatrizCAME.FirstOrDefault(x => x.PlanId == planId);

            if (existente == null)
            {
                model.PlanId = planId;
                model.CreatedAt = DateTime.Now;
                db.MatrizCAME.Add(model);
            }
            else
            {
                model.Id = existente.Id;
                model.PlanId = planId;
                model.CreatedAt = existente.CreatedAt;
                model.UpdatedAt = DateTime.Now;
                db.Entry(existente).CurrentValues.SetValues(model);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "ResumenEstrategico");
        }
    }
}
