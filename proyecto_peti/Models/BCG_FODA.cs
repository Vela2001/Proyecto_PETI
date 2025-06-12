using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_peti.Models
{
    public class BCG_FODA
    {
        
        public int Id { get; set; }

        public int PlanEstrategicoId { get; set; }


        public string Tipo { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }

        public virtual PlanEstrategico PlanEstrategico { get; set; }
    }
}