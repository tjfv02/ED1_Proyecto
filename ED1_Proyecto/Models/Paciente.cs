using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ED1_Proyecto.Models
{
    public class Paciente
    {
        //Datos Personales
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; } //DPI o Partida de Nacimiento
        public string Departamento { get; set; }
        public string Municipio { get; set; }

        //Datos Salud
        public string Sintomas { get; set; }
        public string Descripcion { get; set; }

        public string EstadoPaciente { get; set; } //Contagiado o Sospechoso
    }
}