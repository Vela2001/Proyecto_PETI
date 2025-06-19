using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proyecto_peti.Models
{
    public class Porter_PerfilCompetitivo
    {
        [Key]
        public int Id { get; set; }

        public int PlanEstrategicoId { get; set; }

        public int Rivalidad_Crecimiento { get; set; }
        public int Rivalidad_Naturaleza { get; set; }
        public int Rivalidad_ExcesoCapacidad { get; set; }
        public int Rivalidad_Rentabilidad { get; set; }
        public int Rivalidad_Diferenciacion { get; set; }
        public int Rivalidad_BarrerasSalida { get; set; }

        public int Barreras_Escala { get; set; }
        public int Barreras_Capital { get; set; }
        public int Barreras_Tecnologia { get; set; }
        public int Barreras_Leyes { get; set; }
        public int Barreras_Tramites { get; set; }
        public int Barreras_Reaccion { get; set; }

        public int Clientes_Numero { get; set; }
        public int Clientes_Integracion { get; set; }
        public int Clientes_Rentabilidad { get; set; }
        public int Clientes_CosteCambio { get; set; }

        public int Sustitutos_Disponibilidad { get; set; }


        public string Conclusion { get; set; }


        public string Oportunidad1 { get; set; }


        public string Oportunidad2 { get; set; }


        public string Amenaza1 { get; set; }

        public string Amenaza2 { get; set; }
    }
}