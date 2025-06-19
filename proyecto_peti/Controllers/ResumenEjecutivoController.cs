using proyecto_peti.Models;
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
        private Modelo db = new Modelo();

        // GET: ResumenEjecutivo
        public ActionResult Index()
        {
            if (Session["PlanId"] == null)
                return RedirectToAction("Login", "Account");

            int planId = (int)Session["PlanId"];

            var resumen = new Resumen
            {
                PlanId = planId
            };

            // 1. Información general de la empresa
            var empresa = db.InformacionEmpresa.FirstOrDefault(e => e.PlanId == planId);
            if (empresa != null)
            {
                resumen.NombreEmpresa = empresa.NombreEmpresa;
                //resumen.FechaElaboracion = ;
                resumen.Promotores = empresa.Descripcion;
                //resumen.LogoPath = empresa.LogoPath;
            }

            // 2. Misión y visión
            var mision = db.Mision.FirstOrDefault(m => m.PlanId == planId);
            var vision = db.Vision.FirstOrDefault(v => v.PlanId == planId);
            resumen.Mision = mision?.Contenido;
            resumen.Vision = vision?.Contenido;

            // 3. Valores
            var valores = db.Valores.Where(v => v.PlanId == planId).Select(v => v.Valor).ToList();
            resumen.Valor1 = valores.ElementAtOrDefault(0);
            resumen.Valor2 = valores.ElementAtOrDefault(1);
            resumen.Valor3 = valores.ElementAtOrDefault(2);
            resumen.Valor4 = valores.ElementAtOrDefault(3);
            resumen.Valor5 = valores.ElementAtOrDefault(4);

            // 4. Unidades estratégicas
            var unidades = db.PlanEstrategico.FirstOrDefault(p => p.Id == planId);
            //resumen.UnidadesEstrategicas = unidades?.UnidadesEstrategicas;

            // 5. Objetivos estratégicos y específicos
            var objetivos = db.ObjetivosEstrategicos
                .Where(o => o.PlanId == planId)
                .ToList();

            foreach (var obj in objetivos)
            {
                var item = new ObjetivoEstrategicoItem
                {
                    //MisionAsociada = obj.m,
                    ObjetivoGeneral = obj.Objetivo,
                    ObjetivoEspecifico1 = db.ObjetivosEspecificos
                        .Where(e => e.ObjetivoId == obj.Id)
                        .Select(e => e.Detalle).FirstOrDefault(),
                    ObjetivoEspecifico2 = db.ObjetivosEspecificos
                        .Where(e => e.ObjetivoId == obj.Id)
                        .OrderBy(e => e.Id)
                        .Select(e => e.Detalle)
                        .Skip(1).FirstOrDefault()
                };
                resumen.Objetivos.Add(item);
            }

            // 6. Análisis FODA
            var foda = db.AlmacenFODA.FirstOrDefault(f => f.PlanId == planId);
            if (foda != null)
            {
                resumen.FodaDebilidades = foda.ListaDebilidades;
                resumen.FodaFortalezas = foda.ListaFortalezas;
                resumen.FodaAmenazas = foda.ListaAmenazas;
                resumen.FodaOportunidades = foda.ListaOportunidades;
            }

            // 7. Matriz CAME - identificación estrategia y acciones
            var came = db.MatrizCAME.FirstOrDefault(c => c.PlanId == planId);
            if (came != null)
            {
                //resumen.IdentificacionEstrategia = came.Estrategia;

                resumen.Accion1 = came.Corregir2;
                resumen.Accion2 = came.Corregir3;
                resumen.Accion3 = came.Corregir4;

                resumen.Accion4 = came.Afrontar2;
                resumen.Accion5 = came.Afrontar3;
                resumen.Accion6 = came.Afrontar4;

                resumen.Accion7 = came.Mantener2;
                resumen.Accion8 = came.Mantener3;
                resumen.Accion9 = came.Mantener4;

                resumen.Accion10 = came.Explotar2;
                resumen.Accion11 = came.Explotar3;
                resumen.Accion12 = came.Explotar4;

                // Si hay más acciones (hasta la 16), completar aquí
            }

            // 8. Conclusiones del resumen (si las tienes en otra tabla, como `ResumenEjecutivo`)
            var resumenGuardado = db.ResumenEjecutivo.FirstOrDefault(r => r.PlanId == planId);
            if (resumenGuardado != null)
            {
                resumen.Conclusiones = resumenGuardado.Conclusiones;
            }

            return View(resumen);
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