using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_peti.ViewModel
{
    public class AnalisisPestViewModel
    {
        public int Id { get; set; }

        [Required]
        public int PlanId { get; set; }

        // Preguntas del 1 al 25 para el análisis PEST
        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta1 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta2 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta3 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta4 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta5 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta6 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta7 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta8 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta9 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta10 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta11 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta12 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta13 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta14 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta15 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta16 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta17 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta18 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta19 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta20 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta21 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta22 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta23 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta24 { get; set; }

        [Range(0, 4, ErrorMessage = "El valor debe estar entre 0 y 4")]
        public int? Pregunta25 { get; set; }

        // Oportunidades y Amenazas para el análisis FODA
        [Display(Name = "Oportunidad 3")]
        [StringLength(500, ErrorMessage = "La oportunidad no puede exceder los 500 caracteres")]
        public string Oportunidad3 { get; set; }

        [Display(Name = "Oportunidad 4")]
        [StringLength(500, ErrorMessage = "La oportunidad no puede exceder los 500 caracteres")]
        public string Oportunidad4 { get; set; }

        [Display(Name = "Amenaza 3")]
        [StringLength(500, ErrorMessage = "La amenaza no puede exceder los 500 caracteres")]
        public string Amenaza3 { get; set; }

        [Display(Name = "Amenaza 4")]
        [StringLength(500, ErrorMessage = "La amenaza no puede exceder los 500 caracteres")]
        public string Amenaza4 { get; set; }

        // Propiedades calculadas (solo lectura)
        public double PromedioSocial
        {
            get
            {
                var valores = new int?[] { Pregunta1, Pregunta2, Pregunta3, Pregunta4, Pregunta5 };
                var valoresValidos = valores.Where(v => v.HasValue).Select(v => v.Value);
                if (!valoresValidos.Any()) return 0;
                return Math.Round(valoresValidos.Average(), 2);
            }
        }

        public double PromedioPolitico
        {
            get
            {
                var valores = new int?[] { Pregunta6, Pregunta7, Pregunta8, Pregunta9, Pregunta10 };
                var valoresValidos = valores.Where(v => v.HasValue).Select(v => v.Value);
                if (!valoresValidos.Any()) return 0;
                return Math.Round(valoresValidos.Average(), 2);
            }
        }

        public double PromedioEconomico
        {
            get
            {
                var valores = new int?[] { Pregunta11, Pregunta12, Pregunta13, Pregunta14, Pregunta15 };
                var valoresValidos = valores.Where(v => v.HasValue).Select(v => v.Value);
                if (!valoresValidos.Any()) return 0;
                return Math.Round(valoresValidos.Average(), 2);
            }
        }

        public double PromedioTecnologico
        {
            get
            {
                var valores = new int?[] { Pregunta16, Pregunta17, Pregunta18, Pregunta19, Pregunta20 };
                var valoresValidos = valores.Where(v => v.HasValue).Select(v => v.Value);
                if (!valoresValidos.Any()) return 0;
                return Math.Round(valoresValidos.Average(), 2);
            }
        }

        public double PromedioAmbiental
        {
            get
            {
                var valores = new int?[] { Pregunta21, Pregunta22, Pregunta23, Pregunta24, Pregunta25 };
                var valoresValidos = valores.Where(v => v.HasValue).Select(v => v.Value);
                if (!valoresValidos.Any()) return 0;
                return Math.Round(valoresValidos.Average(), 2);
            }
        }

        // Fechas de auditoría
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime? FechaModificacion { get; set; }

        // Constructor
        public AnalisisPestViewModel()
        {
            // Inicializar valores por defecto si es necesario
            Oportunidad3 = "";
            Oportunidad4 = "";
            Amenaza3 = "";
            Amenaza4 = "";
        }
    }
}