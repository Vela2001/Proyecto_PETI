namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnalisisPEST")]
    public partial class AnalisisPEST
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlanId { get; set; }

        // Preguntas del análisis PEST (valores de 0 a 4)
        public int? Pregunta1 { get; set; }
        public int? Pregunta2 { get; set; }
        public int? Pregunta3 { get; set; }
        public int? Pregunta4 { get; set; }
        public int? Pregunta5 { get; set; }

        public int? Pregunta6 { get; set; }
        public int? Pregunta7 { get; set; }
        public int? Pregunta8 { get; set; }
        public int? Pregunta9 { get; set; }
        public int? Pregunta10 { get; set; }

        public int? Pregunta11 { get; set; }
        public int? Pregunta12 { get; set; }
        public int? Pregunta13 { get; set; }
        public int? Pregunta14 { get; set; }
        public int? Pregunta15 { get; set; }

        public int? Pregunta16 { get; set; }
        public int? Pregunta17 { get; set; }
        public int? Pregunta18 { get; set; }
        public int? Pregunta19 { get; set; }
        public int? Pregunta20 { get; set; }

        public int? Pregunta21 { get; set; }
        public int? Pregunta22 { get; set; }
        public int? Pregunta23 { get; set; }
        public int? Pregunta24 { get; set; }
        public int? Pregunta25 { get; set; }


        [StringLength(500)]
        public string Oportunidad3 { get; set; }

        [StringLength(500)]
        public string Oportunidad4 { get; set; }

        [StringLength(500)]
        public string Amenaza3 { get; set; }

        [StringLength(500)]
        public string Amenaza4 { get; set; }

        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }
}
