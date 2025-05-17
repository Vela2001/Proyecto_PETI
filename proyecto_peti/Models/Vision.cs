namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vision")]
    public partial class Vision
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public string Contenido { get; set; }

<<<<<<< HEAD
=======
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }
}
