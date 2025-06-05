using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_peti.Models
{
    [Table("IdentificacionEstrategias")]
    public class IdentificacionEstrategias
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlanId { get; set; }

        public string ListaFortalezas { get; set; }
        public string ListaDebilidades { get; set; }
        public string ListaOportunidades { get; set; }
        public string ListaAmenazas { get; set; }

        // FO
        public int? FO_F1_O1 { get; set; }
        public int? FO_F1_O2 { get; set; }
        public int? FO_F1_O3 { get; set; }
        public int? FO_F1_O4 { get; set; }
        public int? FO_F2_O1 { get; set; }
        public int? FO_F2_O2 { get; set; }
        public int? FO_F2_O3 { get; set; }
        public int? FO_F2_O4 { get; set; }
        public int? FO_Total { get; set; }

        // FA
        public int? FA_F1_A1 { get; set; }
        public int? FA_F1_A2 { get; set; }
        public int? FA_F1_A3 { get; set; }
        public int? FA_F1_A4 { get; set; }
        public int? FA_F2_A1 { get; set; }
        public int? FA_F2_A2 { get; set; }
        public int? FA_F2_A3 { get; set; }
        public int? FA_F2_A4 { get; set; }
        public int? FA_Total { get; set; }

        // DO
        public int? DO_D1_O1 { get; set; }
        public int? DO_D1_O2 { get; set; }
        public int? DO_D1_O3 { get; set; }
        public int? DO_D1_O4 { get; set; }
        public int? DO_D2_O1 { get; set; }
        public int? DO_D2_O2 { get; set; }
        public int? DO_D2_O3 { get; set; }
        public int? DO_D2_O4 { get; set; }
        public int? DO_Total { get; set; }

        // DA
        public int? DA_D1_A1 { get; set; }
        public int? DA_D1_A2 { get; set; }
        public int? DA_D1_A3 { get; set; }
        public int? DA_D1_A4 { get; set; }
        public int? DA_D2_A1 { get; set; }
        public int? DA_D2_A2 { get; set; }
        public int? DA_D2_A3 { get; set; }
        public int? DA_D2_A4 { get; set; }
        public int? DA_Total { get; set; }

        // Síntesis
        public int? PuntajeFO { get; set; }
        public int? PuntajeFA { get; set; }
        public int? PuntajeDO { get; set; }
        public int? PuntajeDA { get; set; }

        public string TipoEstrategiaFinal { get; set; }
        public string DescripcionFinal { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}