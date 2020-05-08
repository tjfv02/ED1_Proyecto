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

        public string CadenaUnica { get; set; }

        //public List<Paciente> DatosPacientes = new List<Paciente>();
                           //String 
        //public HashTable<string, Hospital> Camas = new HashTable<string, Hospital>();

        //void CadenaUnica()
        //{
        //    // hospital + numero de cama 
        //    string CadenaUnica;
        //    CadenaUnica = 
        //}
    }
}