using ClassLibrary1.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ED1_Proyecto.Models
{
    public class Hospital
    {
        public string Ubicacion { get; set; }
        public int NumeroCamas { get; set; }
        public int CamasLlenas { get; set; }

        public List<Paciente> DatosPacientes = new List<Paciente>();
        public HashTable<int, Hospital> Camas = new HashTable<int, Hospital>();

        //public void Llenar
    }
}