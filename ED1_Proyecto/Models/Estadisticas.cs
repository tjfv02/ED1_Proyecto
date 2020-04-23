using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ED1_Proyecto.Models
{
    public class Estadisticas
    {
        public int IngresoContagiado { get; set; }
        public int IngresoSospechosos { get; set; }
        public int PorcentajeSospechosos { get; set; }
        public int Positivos { get; set; }
        public int CantidadEgresados { get; set; }
    }
}