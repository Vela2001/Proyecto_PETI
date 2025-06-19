using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_peti.ViewModel
{
    public class Resumen
    {
        public int Id { get; set; }
        public int PlanId { get; set; }

        [Display(Name = "Nombre de la empresa / proyecto")]
        public string NombreEmpresa { get; set; }

        [Display(Name = "Fecha de elaboración")]
        [DataType(DataType.Date)]
        public DateTime? FechaElaboracion { get; set; }

        [Display(Name = "Emprendedores / promotores")]
        public string Promotores { get; set; }

        // Para subir el logo. Usa IFormFile si estás en .NET Core.
        [Display(Name = "Logo de la empresa")]
        public HttpPostedFileBase LogoFile { get; set; }
        // Guarda la ruta del logo ya subido para mostrarlo
        public string LogoPath { get; set; }

        public string Mision { get; set; }
        public string Vision { get; set; }

        // Múltiples campos para los valores
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }
        public string Valor4 { get; set; }
        public string Valor5 { get; set; }

        [Display(Name = "Unidades Estratégicas")]
        public string UnidadesEstrategicas { get; set; }

        // Para la tabla de Objetivos
        public List<ObjetivoEstrategicoItem> Objetivos { get; set; }

        // Para el cuadro de Análisis FODA (se asume que son de solo lectura)
        [DataType(DataType.MultilineText)]
        public string FodaDebilidades { get; set; }
        [DataType(DataType.MultilineText)]
        public string FodaAmenazas { get; set; }
        [DataType(DataType.MultilineText)]
        public string FodaFortalezas { get; set; }
        [DataType(DataType.MultilineText)]
        public string FodaOportunidades { get; set; }

        [Display(Name = "Identificación de Estrategia")]
        public string IdentificacionEstrategia { get; set; }

        // Para las 16 acciones competitivas
        public string Accion1 { get; set; }
        public string Accion2 { get; set; }
        public string Accion3 { get; set; }
        public string Accion4 { get; set; }
        public string Accion5 { get; set; }
        public string Accion6 { get; set; }
        public string Accion7 { get; set; }
        public string Accion8 { get; set; }
        public string Accion9 { get; set; }
        public string Accion10 { get; set; }
        public string Accion11 { get; set; }
        public string Accion12 { get; set; }
        public string Accion13 { get; set; }
        public string Accion14 { get; set; }
        public string Accion15 { get; set; }
        public string Accion16 { get; set; }

        public string Conclusiones { get; set; }

        public Resumen()
        {
            // Inicializamos la lista para evitar errores si viene vacía
            Objetivos = new List<ObjetivoEstrategicoItem>();
        }
    }
    // Clase auxiliar para la tabla de objetivos
    public class ObjetivoEstrategicoItem
    {
        public string MisionAsociada { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string ObjetivoEspecifico1 { get; set; }
        public string ObjetivoEspecifico2 { get; set; }
    }
}