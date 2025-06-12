using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_peti.Models
{
    public class BCG_DemandaGlobal
    {
        public int Id { get; set; }
        public int PlanEstrategicoId { get; set; }
        public int Producto { get; set; }
        public int Periodo { get; set; }
        public decimal Demanda { get; set; }


        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }

}