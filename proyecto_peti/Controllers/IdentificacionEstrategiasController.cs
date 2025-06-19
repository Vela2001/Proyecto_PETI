using System;
using System.Linq;
using System.Web.Mvc;
using proyecto_peti.Models;
using proyecto_peti.ViewModel;

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

            var matriz = db.AlmacenFODA.FirstOrDefault(m => m.PlanId == planId);

            var viewModel = new MatrizFODAViewModel();

            if (matriz != null)
            {
                viewModel.Id = matriz.Id;
                viewModel.ListaFortalezas = matriz.ListaFortalezas;
                viewModel.ListaDebilidades = matriz.ListaDebilidades;
                viewModel.ListaOportunidades = matriz.ListaOportunidades;
                viewModel.ListaAmenazas = matriz.ListaAmenazas;
                viewModel.PuntajeFO = matriz.PuntajeFO;
                viewModel.PuntajeFA = matriz.PuntajeFA;
                viewModel.PuntajeDO = matriz.PuntajeDO;
                viewModel.PuntajeDA = matriz.PuntajeDA;

                foreach (var prop in typeof(AlmacenFODA).GetProperties())
                {
                    string name = prop.Name;
                    if (name.StartsWith("FO_"))
                        viewModel.FO[name] = (int)(prop.GetValue(matriz) ?? 0);
                    else if (name.StartsWith("FA_"))
                        viewModel.FA[name] = (int)(prop.GetValue(matriz) ?? 0);
                    else if (name.StartsWith("DO_"))
                        viewModel.DO[name] = (int)(prop.GetValue(matriz) ?? 0);
                    else if (name.StartsWith("DA_"))
                        viewModel.DA[name] = (int)(prop.GetValue(matriz) ?? 0);
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult GuardarMatrizFODA(FormCollection form)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var model = new MatrizFODAViewModel
            {
                Id = int.TryParse(form["Id"], out int id) ? id : 0,
                ListaFortalezas = form["ListaFortalezas"],
                ListaDebilidades = form["ListaDebilidades"],
                ListaOportunidades = form["ListaOportunidades"],
                ListaAmenazas = form["ListaAmenazas"],
                PuntajeFO = int.TryParse(form["PuntajeFO"], out int pfo) ? pfo : 0,
                PuntajeFA = int.TryParse(form["PuntajeFA"], out int pfa) ? pfa : 0,
                PuntajeDO = int.TryParse(form["PuntajeDO"], out int pdo) ? pdo : 0,
                PuntajeDA = int.TryParse(form["PuntajeDA"], out int pda) ? pda : 0
            };

            // Cargar los valores dinámicos FO, FA, DO, DA
            foreach (string key in form.AllKeys)
            {
                if (key.StartsWith("FO_"))
                    model.FO[key] = int.TryParse(form[key], out int val) ? val : 0;
                else if (key.StartsWith("FA_"))
                    model.FA[key] = int.TryParse(form[key], out int val) ? val : 0;
                else if (key.StartsWith("DO_"))
                    model.DO[key] = int.TryParse(form[key], out int val) ? val : 0;
                else if (key.StartsWith("DA_"))
                    model.DA[key] = int.TryParse(form[key], out int val) ? val : 0;
            }

            // Buscar si ya existe registro por PlanId
            var entidad = db.AlmacenFODA.FirstOrDefault(e => e.PlanId == planId);

            if (entidad == null)
            {
                entidad = new AlmacenFODA
                {
                    PlanId = planId
                };
                db.AlmacenFODA.Add(entidad);
            }

            // Asignar valores estáticos
            entidad.ListaFortalezas = model.ListaFortalezas;
            entidad.ListaDebilidades = model.ListaDebilidades;
            entidad.ListaOportunidades = model.ListaOportunidades;
            entidad.ListaAmenazas = model.ListaAmenazas;
            entidad.PuntajeFO = model.PuntajeFO;
            entidad.PuntajeFA = model.PuntajeFA;
            entidad.PuntajeDO = model.PuntajeDO;
            entidad.PuntajeDA = model.PuntajeDA;

            // Asignar los valores dinámicos con reflexión
            foreach (var prop in typeof(AlmacenFODA).GetProperties())
            {
                string propName = prop.Name;

                if (propName.StartsWith("FO_") && model.FO.ContainsKey(propName))
                    prop.SetValue(entidad, model.FO[propName]);
                else if (propName.StartsWith("FA_") && model.FA.ContainsKey(propName))
                    prop.SetValue(entidad, model.FA[propName]);
                else if (propName.StartsWith("DO_") && model.DO.ContainsKey(propName))
                    prop.SetValue(entidad, model.DO[propName]);
                else if (propName.StartsWith("DA_") && model.DA.ContainsKey(propName))
                    prop.SetValue(entidad, model.DA[propName]);
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
