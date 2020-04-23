using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ED1_Proyecto.Models
{
    public class Hospital
    {
        public string Ubicacion { get; set; }
        public string Categoria { get; set; } //Edades??
        public string Fecha { get; set; }
        public string HoraIngreso { get; set; }

        public List<Paciente> DatosPacientes = new List<Paciente>();
    }
}