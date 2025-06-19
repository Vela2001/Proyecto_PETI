using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_peti.ViewModel
{
    public class PerfilCompetitivoViewModel
    {
        public int PlanEstrategicoId { get; set; }

        public int rivalidad_crecimiento { get; set; }
        public int rivalidad_naturaleza { get; set; }
        public int rivalidad_exceso_capacidad { get; set; }
        public int rivalidad_rentabilidad { get; set; }
        public int rivalidad_diferenciacion { get; set; }
        public int rivalidad_barreras_salida { get; set; }

        public int barreras_escala { get; set; }
        public int barreras_capital { get; set; }
        public int barreras_tecnologia { get; set; }
        public int barreras_leyes { get; set; }
        public int barreras_tramites { get; set; }
        public int barreras_reaccion { get; set; }

        public int clientes_numero { get; set; }
        public int clientes_integracion { get; set; }
        public int clientes_rentabilidad { get; set; }
        public int clientes_coste_cambio { get; set; }

        public int sustitutos_disponibilidad { get; set; }

        public string conclusion { get; set; }

        public string oportunidad1 { get; set; }
        public string oportunidad2 { get; set; }
        public string amenaza1 { get; set; }
        public string amenaza2 { get; set; }
    }

}