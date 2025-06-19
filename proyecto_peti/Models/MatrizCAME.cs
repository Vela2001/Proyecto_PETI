namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatrizCAME")]
    public partial class MatrizCAME
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public string Corregir1 { get; set; }
        public string Corregir2 { get; set; }
        public string Corregir3 { get; set; }
        public string Corregir4 { get; set; }

        public string Afrontar1 { get; set; }
        public string Afrontar2 { get; set; }

        public string Afrontar3 { get; set; }
        public string Afrontar4 { get; set; }
        public string Mantener1 { get; set; }


        public string Mantener2 { get; set; }
        public string Mantener3 { get; set; }
        public string Mantener4 { get; set; }

        public string Explotar1 { get; set; }
        public string Explotar2 { get; set; }
        public string Explotar3 { get; set; }
        public string Explotar4 { get; set; }

        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }
}
