namespace proyecto_peti.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ObjetivosEspecificos
    {
        public int Id { get; set; }

        public int ObjetivoId { get; set; }

        public string Detalle { get; set; }

<<<<<<< HEAD
=======
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

>>>>>>> 311d409eeb8b57bb99baeb97d542522fd02de8f4
        public virtual ObjetivosEstrategicos ObjetivosEstrategicos { get; set; }
    }
}
