using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_peti.Models
{
    [Table("almacen")]
    public class AlmacenFODA
    {
        [Key]
        public int Id { get; set; }

        public int PlanId { get; set; }

        public string ListaFortalezas { get; set; }
        public string ListaDebilidades { get; set; }
        public string ListaOportunidades { get; set; }
        public string ListaAmenazas { get; set; }

        public int PuntajeFO { get; set; }
        public int PuntajeFA { get; set; }
        public int PuntajeDO { get; set; }
        public int PuntajeDA { get; set; }

        // FO
        public int FO_F1_O1 { get; set; }
        public int FO_F1_O2 { get; set; }
        public int FO_F1_O3 { get; set; }
        public int FO_F1_O4 { get; set; }
        public int FO_F2_O1 { get; set; }
        public int FO_F2_O2 { get; set; }
        public int FO_F2_O3 { get; set; }
        public int FO_F2_O4 { get; set; }
        public int FO_F3_O1 { get; set; }
        public int FO_F3_O2 { get; set; }
        public int FO_F3_O3 { get; set; }
        public int FO_F3_O4 { get; set; }
        public int FO_F4_O1 { get; set; }
        public int FO_F4_O2 { get; set; }
        public int FO_F4_O3 { get; set; }
        public int FO_F4_O4 { get; set; }

        // FA
        public int FA_F1_A1 { get; set; }
        public int FA_F1_A2 { get; set; }
        public int FA_F1_A3 { get; set; }
        public int FA_F1_A4 { get; set; }
        public int FA_F2_A1 { get; set; }
        public int FA_F2_A2 { get; set; }
        public int FA_F2_A3 { get; set; }
        public int FA_F2_A4 { get; set; }
        public int FA_F3_A1 { get; set; }
        public int FA_F3_A2 { get; set; }
        public int FA_F3_A3 { get; set; }
        public int FA_F3_A4 { get; set; }
        public int FA_F4_A1 { get; set; }
        public int FA_F4_A2 { get; set; }
        public int FA_F4_A3 { get; set; }
        public int FA_F4_A4 { get; set; }

        // DO
        public int DO_D1_O1 { get; set; }
        public int DO_D1_O2 { get; set; }
        public int DO_D1_O3 { get; set; }
        public int DO_D1_O4 { get; set; }
        public int DO_D2_O1 { get; set; }
        public int DO_D2_O2 { get; set; }
        public int DO_D2_O3 { get; set; }
        public int DO_D2_O4 { get; set; }
        public int DO_D3_O1 { get; set; }
        public int DO_D3_O2 { get; set; }
        public int DO_D3_O3 { get; set; }
        public int DO_D3_O4 { get; set; }
        public int DO_D4_O1 { get; set; }
        public int DO_D4_O2 { get; set; }
        public int DO_D4_O3 { get; set; }
        public int DO_D4_O4 { get; set; }

        // DA
        public int DA_D1_A1 { get; set; }
        public int DA_D1_A2 { get; set; }
        public int DA_D1_A3 { get; set; }
        public int DA_D1_A4 { get; set; }
        public int DA_D2_A1 { get; set; }
        public int DA_D2_A2 { get; set; }
        public int DA_D2_A3 { get; set; }
        public int DA_D2_A4 { get; set; }
        public int DA_D3_A1 { get; set; }
        public int DA_D3_A2 { get; set; }
        public int DA_D3_A3 { get; set; }
        public int DA_D3_A4 { get; set; }
        public int DA_D4_A1 { get; set; }
        public int DA_D4_A2 { get; set; }
        public int DA_D4_A3 { get; set; }
        public int DA_D4_A4 { get; set; }
    }
}
