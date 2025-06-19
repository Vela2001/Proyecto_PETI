using proyecto_peti.Models;
using System.Collections.Generic;
namespace proyecto_peti.ViewModel
{

    public class MatrizFODAViewModel
    {
        public int Id { get; set; }

        // Factores
        public string ListaFortalezas { get; set; }
        public string ListaDebilidades { get; set; }
        public string ListaOportunidades { get; set; }
        public string ListaAmenazas { get; set; }

        // Puntajes
        public int PuntajeFO { get; set; }
        public int PuntajeFA { get; set; }
        public int PuntajeDO { get; set; }
        public int PuntajeDA { get; set; }

        // Matrices (clave dinámica tipo "FO_F1_O1", etc.)
        public Dictionary<string, int> FO { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> FA { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> DO { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> DA { get; set; } = new Dictionary<string, int>();


    }
}