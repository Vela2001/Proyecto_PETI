using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyecto_peti.ViewModel
{
    public class BCGMatrizViewModel
    {
        public List<ProductoInput> Productos { get; set; } = new List<ProductoInput>();
        public List<string> Fortalezas { get; set; } = new List<string>();
        public List<string> Debilidades { get; set; } = new List<string>();
    }

    public class ProductoInput
    {
        public string Nombre { get; set; }
        public decimal Venta { get; set; }
        public decimal PRM { get; set; }
        public List<decimal> TCM { get; set; }
        public List<decimal> Demanda { get; set; } 
        public List<decimal> Competidores { get; set; }
    }

    public class CompetidorInput
    {
        public string Nombre { get; set; }
        public decimal Venta { get; set; }
    }



}