using System;
using System.Linq;
using System.Web.Mvc;
using proyecto_peti.Models;
using proyecto_peti.ViewModel;

namespace proyecto_peti.Controllers
{
    public class PorterController : Controller
    {
        private Modelo db = new Modelo();

        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var modelo = db.FuerzasPorter.FirstOrDefault(x => x.PlanId == planId);
            if (modelo == null)
            {
                modelo = new FuerzasPorter { PlanId = planId };
            }

            return View(modelo);
        }

        [HttpPost]
        public ActionResult Index(FuerzasPorter model)
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];
            var existente = db.FuerzasPorter.FirstOrDefault(x => x.PlanId == planId);

            if (existente != null)
            {
                existente.AmenazaNuevos = model.AmenazaNuevos;
                existente.RivalidadCompetidores = model.RivalidadCompetidores;
                existente.PoderClientes = model.PoderClientes;
                existente.PoderProveedores = model.PoderProveedores;
                existente.AmenazaSustitutos = model.AmenazaSustitutos;
            }
            else
            {
                model.PlanId = planId;
                db.FuerzasPorter.Add(model);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "PEST");
        }
        public ActionResult AutoDiagnosticoPorter()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var perfil = db.Porter_PerfilCompetitivo.FirstOrDefault(p => p.PlanEstrategicoId == planId);

            var model = new PerfilCompetitivoViewModel();

            if (perfil != null)
            {
                model.rivalidad_crecimiento = perfil.Rivalidad_Crecimiento;
                model.rivalidad_naturaleza = perfil.Rivalidad_Naturaleza;
                model.rivalidad_exceso_capacidad = perfil.Rivalidad_ExcesoCapacidad;
                model.rivalidad_rentabilidad = perfil.Rivalidad_Rentabilidad;
                model.rivalidad_diferenciacion = perfil.Rivalidad_Diferenciacion;
                model.rivalidad_barreras_salida = perfil.Rivalidad_BarrerasSalida;

                model.barreras_escala = perfil.Barreras_Escala;
                model.barreras_capital = perfil.Barreras_Capital;
                model.barreras_tecnologia = perfil.Barreras_Tecnologia;
                model.barreras_leyes = perfil.Barreras_Leyes;
                model.barreras_tramites = perfil.Barreras_Tramites;
                model.barreras_reaccion = perfil.Barreras_Reaccion;

                model.clientes_numero = perfil.Clientes_Numero;
                model.clientes_integracion = perfil.Clientes_Integracion;
                model.clientes_rentabilidad = perfil.Clientes_Rentabilidad;
                model.clientes_coste_cambio = perfil.Clientes_CosteCambio;

                model.sustitutos_disponibilidad = perfil.Sustitutos_Disponibilidad;

                model.conclusion = perfil.Conclusion;
                model.oportunidad1 = perfil.Oportunidad1;
                model.oportunidad2 = perfil.Oportunidad2;
                model.amenaza1 = perfil.Amenaza1;
                model.amenaza2 = perfil.Amenaza2;
            }

            return View(model);
        }



        [HttpPost]
        public ActionResult GuardarPerfilCompetitivo(PerfilCompetitivoViewModel model)
        {
            int planId = (int)Session["PlanId"];

            var perfilExistente = db.Porter_PerfilCompetitivo
                                    .FirstOrDefault(p => p.PlanEstrategicoId == planId);

            if (perfilExistente != null)
            {
                // Actualizar
                perfilExistente.Rivalidad_Crecimiento = model.rivalidad_crecimiento;
                perfilExistente.Rivalidad_Naturaleza = model.rivalidad_naturaleza;
                perfilExistente.Rivalidad_ExcesoCapacidad = model.rivalidad_exceso_capacidad;
                perfilExistente.Rivalidad_Rentabilidad = model.rivalidad_rentabilidad;
                perfilExistente.Rivalidad_Diferenciacion = model.rivalidad_diferenciacion;
                perfilExistente.Rivalidad_BarrerasSalida = model.rivalidad_barreras_salida;

                perfilExistente.Barreras_Escala = model.barreras_escala;
                perfilExistente.Barreras_Capital = model.barreras_capital;
                perfilExistente.Barreras_Tecnologia = model.barreras_tecnologia;
                perfilExistente.Barreras_Leyes = model.barreras_leyes;
                perfilExistente.Barreras_Tramites = model.barreras_tramites;
                perfilExistente.Barreras_Reaccion = model.barreras_reaccion;

                perfilExistente.Clientes_Numero = model.clientes_numero;
                perfilExistente.Clientes_Integracion = model.clientes_integracion;
                perfilExistente.Clientes_Rentabilidad = model.clientes_rentabilidad;
                perfilExistente.Clientes_CosteCambio = model.clientes_coste_cambio;

                perfilExistente.Sustitutos_Disponibilidad = model.sustitutos_disponibilidad;

                perfilExistente.Conclusion = model.conclusion;
                perfilExistente.Oportunidad1 = model.oportunidad1;
                perfilExistente.Oportunidad2 = model.oportunidad2;
                perfilExistente.Amenaza1 = model.amenaza1;
                perfilExistente.Amenaza2 = model.amenaza2;
            }
            else
            {
                var perfil = new Porter_PerfilCompetitivo
                {
                    PlanEstrategicoId = planId,
                    Rivalidad_Crecimiento = model.rivalidad_crecimiento,
                    Rivalidad_Naturaleza = model.rivalidad_naturaleza,
                    Rivalidad_ExcesoCapacidad = model.rivalidad_exceso_capacidad,
                    Rivalidad_Rentabilidad = model.rivalidad_rentabilidad,
                    Rivalidad_Diferenciacion = model.rivalidad_diferenciacion,
                    Rivalidad_BarrerasSalida = model.rivalidad_barreras_salida,

                    Barreras_Escala = model.barreras_escala,
                    Barreras_Capital = model.barreras_capital,
                    Barreras_Tecnologia = model.barreras_tecnologia,
                    Barreras_Leyes = model.barreras_leyes,
                    Barreras_Tramites = model.barreras_tramites,
                    Barreras_Reaccion = model.barreras_reaccion,

                    Clientes_Numero = model.clientes_numero,
                    Clientes_Integracion = model.clientes_integracion,
                    Clientes_Rentabilidad = model.clientes_rentabilidad,
                    Clientes_CosteCambio = model.clientes_coste_cambio,

                    Sustitutos_Disponibilidad = model.sustitutos_disponibilidad,

                    Conclusion = model.conclusion,
                    Oportunidad1 = model.oportunidad1,
                    Oportunidad2 = model.oportunidad2,
                    Amenaza1 = model.amenaza1,
                    Amenaza2 = model.amenaza2
                };

                db.Porter_PerfilCompetitivo.Add(perfil);
            }

            db.SaveChanges();

            return RedirectToAction("AutoDiagnosticoPorter");
        }


    }
}
