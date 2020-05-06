using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ED1_Proyecto.Models
{
    public class Departamentos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Region { get; set; }

        public  List<Departamentos> DatosDepartamentos = new List<Departamentos>();

        public int DepartamentoAleatorio()
        {
            Random DepRand = new Random();
            LlenandoDepartamentos();
            return DepRand.Next(1, 22);
        }
        public void LlenandoDepartamentos()
        {
            DatosDepartamentos[1].Id = 1;
            DatosDepartamentos[1].Nombre = "Alta Verapaz";
            DatosDepartamentos[1].Region = "Norte";

            DatosDepartamentos[2].Id = 2;
            DatosDepartamentos[2].Nombre = "Baja Verapaz";
            DatosDepartamentos[2].Region = "Norte";

            DatosDepartamentos[3].Id = 3;
            DatosDepartamentos[3].Nombre = "Chimaltenango";
            DatosDepartamentos[3].Region = "Centro";

            DatosDepartamentos[4].Id = 4;
            DatosDepartamentos[4].Nombre = "Chiquimula";
            DatosDepartamentos[4].Region = "Oriente";

            DatosDepartamentos[5].Id = 5;
            DatosDepartamentos[5].Nombre = "Peten";
            DatosDepartamentos[5].Region = "Norte";

            DatosDepartamentos[6].Id = 6;
            DatosDepartamentos[6].Nombre = "El Progreso";
            DatosDepartamentos[6].Region = "Oriente";

            DatosDepartamentos[7].Id = 7;
            DatosDepartamentos[7].Nombre = "Quiche";
            DatosDepartamentos[7].Region = "Occidente";

            DatosDepartamentos[8].Id = 8;
            DatosDepartamentos[8].Nombre = "Escuintla";
            DatosDepartamentos[8].Region = "Sur";

            DatosDepartamentos[9].Id = 9;
            DatosDepartamentos[9].Nombre = "Guatemla";
            DatosDepartamentos[9].Region = "Centro";

            DatosDepartamentos[10].Id = 10;
            DatosDepartamentos[10].Nombre = "Huehuetenango";
            DatosDepartamentos[10].Region = "Occidente";

            DatosDepartamentos[11].Id = 11;
            DatosDepartamentos[11].Nombre = "Izabal";
            DatosDepartamentos[11].Region = "Oriente";

            DatosDepartamentos[12].Id = 12;
            DatosDepartamentos[12].Nombre = "Jalapa";
            DatosDepartamentos[12].Region = "Oriente";

            DatosDepartamentos[13].Id = 13;
            DatosDepartamentos[13].Nombre = "Jutiapa";
            DatosDepartamentos[13].Region = "Oriente";

            DatosDepartamentos[14].Id = 14;
            DatosDepartamentos[14].Nombre = "Quetzaltenango";
            DatosDepartamentos[14].Region = "Occidente";

            DatosDepartamentos[15].Id = 15;
            DatosDepartamentos[15].Nombre = "Retalhuleu";
            DatosDepartamentos[15].Region = "Occidente";

            DatosDepartamentos[16].Id = 16;
            DatosDepartamentos[16].Nombre = "Sacatepequez";
            DatosDepartamentos[16].Region = "Centro";

            DatosDepartamentos[17].Id = 17;
            DatosDepartamentos[17].Nombre = "San Marcos";
            DatosDepartamentos[17].Region = "Occidente";

            DatosDepartamentos[18].Id = 18;
            DatosDepartamentos[18].Nombre = "Santa Rosa";
            DatosDepartamentos[18].Region = "Oriente";

            DatosDepartamentos[19].Id = 19;
            DatosDepartamentos[19].Nombre = "Solola";
            DatosDepartamentos[19].Region = "Occidente";

            DatosDepartamentos[20].Id = 20;
            DatosDepartamentos[20].Nombre = "Suchitepequez";
            DatosDepartamentos[20].Region = "Occidente";

            DatosDepartamentos[21].Id = 21;
            DatosDepartamentos[21].Nombre = "Totonicapan";
            DatosDepartamentos[21].Region = "Occidente";

            DatosDepartamentos[22].Id = 22;
            DatosDepartamentos[22].Nombre = "Zacapa";
            DatosDepartamentos[22].Region = "Oriente";
        }
        
    }
}