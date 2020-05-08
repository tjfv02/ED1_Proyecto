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
            return 0;// DepRand.Next(0, 3);
        }
        public void LlenandoDepartamentos()
        {
            
            DatosDepartamentos.Add( new Departamentos() {
                Id = 1,
                Nombre = "Alta Verapaz",
                Region = "Norte"
            });

            DatosDepartamentos.Add(new Departamentos()
            {
               
                Id = 2,
                Nombre = "Baja Verapaz",
                Region = "Norte"
            });

            DatosDepartamentos.Add(new Departamentos()
            {

                Id = 3,
                Nombre = "Chimaltenango",
                Region = "Centro"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
            Id = 4,
                Nombre = "Chiquimula",
                Region = "Oriente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 5,
                Nombre = "Peten",
                Region = "Norte"

            }); DatosDepartamentos.Add(new Departamentos()
            {
                Id = 6,
                Nombre = "El Progreso",
                Region = "Oriente"

            }); DatosDepartamentos.Add(new Departamentos()
            {
                Id = 7,
                Nombre = "Quiche",
                Region = "Occidente"

            }); DatosDepartamentos.Add(new Departamentos()
            {
                Id = 8,
                Nombre = "Escuintla",
                Region = "Sur"
            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 9,
                Nombre = "Guatemla",
                Region = "Centro"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 10,
                Nombre = "Huehuetenango",
                Region = "Occidente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 11,
                Nombre = "Izabal",
                Region = "Oriente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 12,
                Nombre = "Jalapa",
                Region = "Oriente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {

                Id = 13,
                Nombre = "Jutiapa",
                Region = "Oriente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 14,
                Nombre = "Quetzaltenango",
                Region = "Occidente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 15,
                Nombre = "Retalhuleu",
                Region = "Occidente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 16,
                Nombre = "Sacatepequez",
                Region = "Centro"
            });
            DatosDepartamentos.Add(new Departamentos()
            {
            Id = 17,
                Nombre = "San Marcos",
                Region = "Occidente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 18,
                Nombre = "Santa Rosa",
                Region = "Oriente"

            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 19,
                Nombre = "Solola",
                Region = "Occidente"


            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 20,
                Nombre = "Suchitepequez",
                Region = "Occidente"


            });
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 21,
                Nombre = "Totonicapan",
                Region = "Occidente"

            });






                Id = 22;
                Nombre = "Zacapa";
                Region = "Oriente";
        }
        
    }
}