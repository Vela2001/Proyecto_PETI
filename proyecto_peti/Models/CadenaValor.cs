namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CadenaValor")]
    public partial class CadenaValor
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public string ActividadPrimaria { get; set; }

        public string ActividadSecundaria { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }
}
