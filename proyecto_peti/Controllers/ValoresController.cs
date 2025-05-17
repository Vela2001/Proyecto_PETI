<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
=======
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using proyecto_peti.Models;
>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4

namespace proyecto_peti.Controllers
{
    public class ValoresController : Controller
    {
<<<<<<< HEAD
        // GET: Valores
        public ActionResult Index()
        {
            return View();
        }
    }
}
=======
        private Modelo db = new Modelo();

        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var valores = db.Valores.Where(v => v.PlanId == planId).OrderBy(v => v.Id).ToList();

            while (valores.Count < 3) // Solo 3 como en el Excel
                valores.Add(new Valores { PlanId = planId });

            return View(valores);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(List<Valores> model)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var existentes = db.Valores.Where(v => v.PlanId == planId).ToList();
            db.Valores.RemoveRange(existentes);
            db.SaveChanges();

            foreach (var valor in model)
            {
                if (!string.IsNullOrWhiteSpace(valor.Valor))
                {
                    valor.PlanId = planId;
                    valor.CreatedAt = System.DateTime.Now;
                    db.Valores.Add(valor);
                }
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Objetivos");
        }
    }
}
>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
