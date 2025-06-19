namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ResumenEjecutivo")]
    public partial class ResumenEjecutivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlanId { get; set; }

        [StringLength(200)]
        public string NombreEmpresa { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FechaElaboracion { get; set; }

        [StringLength(200)]
        public string Promotores { get; set; }

        [StringLength(300)]
        public string LogoPath { get; set; }

        public string Mision { get; set; }
        public string Vision { get; set; }

        [StringLength(200)]
        public string Valor1 { get; set; }

        [StringLength(200)]
        public string Valor2 { get; set; }

        [StringLength(200)]
        public string Valor3 { get; set; }

        [StringLength(200)]
        public string Valor4 { get; set; }

        [StringLength(200)]
        public string Valor5 { get; set; }

        public string UnidadesEstrategicas { get; set; }

        // Objetivos estratégicos
        public string Objetivo_MisionAsociada1 { get; set; }
        public string Objetivo_General1 { get; set; }
        public string Objetivo_Especifico1_1 { get; set; }
        public string Objetivo_Especifico1_2 { get; set; }

        // Análisis FODA
        public string FodaFortalezas { get; set; }
        public string FodaDebilidades { get; set; }
        public string FodaOportunidades { get; set; }
        public string FodaAmenazas { get; set; }

        public string IdentificacionEstrategia { get; set; }

        // Acciones competitivas (16 acciones)
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

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

        [ForeignKey("PlanId")]
        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }
}
