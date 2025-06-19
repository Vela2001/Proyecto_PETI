using proyecto_peti.Models;
using proyecto_peti.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_peti.Controllers
{
    public class MatrizParticipacionController : Controller
    {
        // GET: MatrizParticipacion
        public ActionResult Index()
        {
            return View();
        }

        private Modelo db = new Modelo();

        public ActionResult AutoDiagnosticoBCG()
        {
            if (Session["PlanId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            int planId = (int)Session["PlanId"];

            var ventasGuardadas = db.BCG_Ventas
                                    .Where(v => v.PlanEstrategicoId == planId)
                                    .ToList();

            var tasasGuardadas = db.BCG_TasaCrecimientoMercado
                                    .Where(t => t.PlanEstrategicoId == planId)
                                    .ToList();

            var prmGuardados = db.BCG_PRM
                                 .Where(p => p.PlanEstrategicoId == planId)
                                 .ToList();

            var demandasGuardadas = db.BCG_DemandaGlobal
                                      .Where(d => d.PlanEstrategicoId == planId)
                                      .ToList();

            var CompetidoresGuardadas = db.BCG_ParticipacionMercado
                                              .Where(p => p.PlanEstrategicoId == planId)
                                              .ToList();

            var FodaGuardadas = db.BCG_FODA
                                  .Where(p => p.PlanEstrategicoId == planId)
                                  .ToList();

            var fortalezas = FodaGuardadas
                                .Where(f => f.Tipo == "Fortaleza")
                                .Select(f => f.Descripcion)
                                .ToList(); 

            var debilidades = FodaGuardadas
                                .Where(f => f.Tipo == "Debilidad")
                                .Select(f => f.Descripcion)
                                .ToList();

            while (fortalezas.Count < 2) {fortalezas.Add(string.Empty);}
            while (debilidades.Count < 2) { debilidades.Add(string.Empty); }





            var model = new BCGMatrizViewModel
            {
                Fortalezas = fortalezas,

                Debilidades = debilidades,

                Productos = Enumerable.Range(1, 5).Select(i =>
                    {
                        var venta = ventasGuardadas.FirstOrDefault(v => v.Producto == i);
                        var prm = prmGuardados.FirstOrDefault(p => p.Producto == i);


                        var tcmProducto = tasasGuardadas
                            .Where(t => t.Producto == i)
                            .OrderBy(t => t.Periodo)
                            .Select(t => t.TasaCrecimiento)
                            .ToList();

                        var demandaProducto = demandasGuardadas
                            .Where(d => d.Producto == i)
                            .OrderBy(d => d.Periodo)
                            .Select(d => d.Demanda)
                            .ToList();
                        var CompetidoresProducto = CompetidoresGuardadas
                            .Where(c => c.Producto == i)
                            .OrderBy(c => c.Periodo)
                            .Select(c => c.Participacion)
                            .ToList();

                        while (tcmProducto.Count < 6)
                        {
                            tcmProducto.Add(0);
                        }
                        while (demandaProducto.Count < 6)
                        {
                            demandaProducto.Add(0);
                        }

                        while (CompetidoresProducto.Count < 12)
                        {
                            CompetidoresProducto.Add(0);
                        }

                        return new ProductoInput
                        {
                            Nombre = $"Producto {i}",
                            Venta = venta != null ? venta.Monto : 0,
                            TCM = tcmProducto != null ? tcmProducto : new List<decimal> { 0 , 0, 0, 0, 0, 0 },
                            PRM = prm?.Prm ?? 0,
                            Demanda = demandaProducto != null ? demandaProducto : new List<decimal> { 0, 0, 0, 0, 0, 0 },
                            Competidores = CompetidoresProducto != null ? CompetidoresProducto : new List<decimal> { 0, 0, 0, 0, 0, 0 }
                        
                        };

                }).ToList()
            };

            return View(model);
        }




        [HttpPost]
        public ActionResult GuardarVentas(BCGMatrizViewModel model)
        {
            if (Session["PlanId"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            int planId = (int)Session["PlanId"];

            foreach (var prod in model.Productos.Select((p, index) => new { p, index }))
            {
                int productoId = prod.index + 1;

                var ventaExistente = db.BCG_Ventas
                    .FirstOrDefault(v => v.PlanEstrategicoId == planId && v.Producto == productoId);

                if (ventaExistente != null)
                {
                    ventaExistente.Monto = prod.p.Venta;
                }
                else
                {
                    var nuevaVenta = new BCG_Ventas
                    {
                        PlanEstrategicoId = planId,
                        Producto = productoId,
                        Monto = prod.p.Venta
                    };
                    db.BCG_Ventas.Add(nuevaVenta);
                }
            }

            for (int i = 0; i < model.Productos.Count; i++)
            {
                var producto = model.Productos[i];
                int productoId = i + 1;

                if (producto.TCM != null)
                {
                    for (int j = 0; j < producto.TCM.Count; j++)
                    {
                        int periodo = 2012 + j;

                        var tcmExistente = db.BCG_TasaCrecimientoMercado
                            .FirstOrDefault(t => t.PlanEstrategicoId == planId &&
                                                 t.Producto == productoId &&
                                                 t.Periodo == periodo);

                        if (tcmExistente != null)
                        {
                            tcmExistente.TasaCrecimiento = producto.TCM[j];
                        }
                        else
                        {
                            db.BCG_TasaCrecimientoMercado.Add(new BCG_TasaCrecimientoMercado
                            {
                                PlanEstrategicoId = planId,
                                Producto = productoId,
                                Periodo = periodo,
                                TasaCrecimiento = producto.TCM[j]
                            });
                        }
                    }
                }
            }

            for (int i = 0; i < model.Productos.Count; i++)
            {
                int productoId = i + 1;
                decimal prmValue = model.Productos[i].PRM;

                var prmExistente = db.BCG_PRM
                    .FirstOrDefault(p => p.PlanEstrategicoId == planId && p.Producto == productoId);

                if (prmExistente != null)
                {
                    prmExistente.Prm = prmValue;
                }
                else
                {
                    db.BCG_PRM.Add(new BCG_PRM
                    {
                        PlanEstrategicoId = planId,
                        Producto = productoId,
                        Prm = prmValue
                    });
                }
            }

            for (int i = 0; i < model.Productos.Count; i++)
            {
                var producto = model.Productos[i];
                int productoId = i + 1;

                if (producto.Demanda != null)
                {
                    for (int j = 0; j < producto.Demanda.Count; j++)
                    {
                        int periodo = 2012 + j;

                        var demandaExistente = db.BCG_DemandaGlobal
                            .FirstOrDefault(d => d.PlanEstrategicoId == planId &&
                                                 d.Producto == productoId &&
                                                 d.Periodo == periodo);

                        if (demandaExistente != null)
                        {
                            demandaExistente.Demanda = producto.Demanda[j];
                        }
                        else
                        {
                            db.BCG_DemandaGlobal.Add(new BCG_DemandaGlobal
                            {
                                PlanEstrategicoId = planId,
                                Producto = productoId,
                                Periodo = periodo,
                                Demanda = producto.Demanda[j]
                            });
                        }
                    }
                }
            }
            for (int i = 0; i < model.Productos.Count; i++)
            {
                var producto = model.Productos[i];
                int productoId = i + 1;

                if (producto.Competidores != null)
                {
                    for (int j = 0; j < producto.Competidores.Count; j++)
                    {
                        var comp = producto.Competidores[j];
                        int periodo = j + 1; // usamos el índice como "Periodo"

                        var ventaExistente = db.BCG_ParticipacionMercado
                            .FirstOrDefault(c => c.PlanEstrategicoId == planId &&
                                                 c.Producto == productoId &&
                                                 c.Periodo == periodo);

                        if (ventaExistente != null)
                        {
                            ventaExistente.Participacion = comp;
                        }
                        else
                        {
                            db.BCG_ParticipacionMercado.Add(new BCG_ParticipacionMercado
                            {
                                PlanEstrategicoId = planId,
                                Producto = productoId,
                                Periodo = periodo,
                                Participacion = comp
                            });
                        }
                    }
                }
            }

            for (int i = 0; i < model.Fortalezas.Count; i++)
            {
                db.BCG_FODA.Add(new BCG_FODA
                {
                    PlanEstrategicoId = planId,
                    Tipo = "Fortaleza",
                    Codigo = $"F{i + 3}",
                    Descripcion = model.Fortalezas[i]
                });
            }

            for (int i = 0; i < model.Debilidades.Count; i++)
            {
                db.BCG_FODA.Add(new BCG_FODA
                {
                    PlanEstrategicoId = planId,
                    Tipo = "Debilidad",
                    Codigo = $"D{i + 3}", 
                    Descripcion = model.Debilidades[i]
                });
            }

            db.SaveChanges();

            TempData["Mensaje"] = "Ventas guardadas correctamente";
            return RedirectToAction("AutoDiagnosticoBCG");



        }

       

    }
}