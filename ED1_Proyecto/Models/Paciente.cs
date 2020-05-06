using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ED1_Proyecto.Models
{
    public class Paciente
    {
        /*
         --Categorias Edad--
         3era edad +60
         Adulto
         niño o joven
         Receien nacido
             */

        //Datos Personales
        public int Id { get;  set; }
        public int Edad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Identificacion { get; set; } //DPI o Partida de Nacimiento
        public string Departamento { get; set; }
        public string Municipio { get; set; }

        //Datos Salud
        public string Sintomas { get; set; }
        public string DescripcionContagioPosible { get; set; }

        //Descripcion 
       /*
        Probabilidad base = 5%
        Viaje a Europa +10%
        Conocido contagiado +15%
        Familiar Contagido +30%
        Reuniones sociales con sospedhosos +5%
             */

        public string EstadoPaciente { get; set; } //Contagiado o Sospechoso
    }
}