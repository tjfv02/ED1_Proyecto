using ED1_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ED1_Proyecto.Controllers
{
    public class PacientesController : Controller
    {
        public static List<Paciente> DatosPacientes = new List<Paciente>();
        public static List<Departamentos> DatosDepartamentos = new List<Departamentos>();


        // GET: Pacientes
        public ActionResult Index()
        {
            return View(DatosPacientes);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Paciente AgregarPaciente = new Paciente()
                {
                    //Datos Personales
                    Edad = Convert.ToInt32(collection["Edad"]),
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Identificacion = collection["Identificacion"],
                    Departamento = collection["Departamento"],
                    Municipio = collection["Municipio"],

                    //Salud

                    Sintomas = collection["Sintomas"],
                    DescripcionContagioPosible = collection["Descripcion"],
                    EstadoPaciente = collection["EstadoPaciente"]

                };
                DatosPacientes.Add(AgregarPaciente);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pacientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pacientes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void LlenadoDepartamentos()
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

            DatosDepartamentos[5].Id = 3;
            DatosDepartamentos[5].Nombre = "Peten";
            DatosDepartamentos[5].Region = "Norte";

            DatosDepartamentos[6].Id = 3;
            DatosDepartamentos[6].Nombre = "El Progreso";
            DatosDepartamentos[6].Region = "Centro";

            DatosDepartamentos[7].Id = 3;
            DatosDepartamentos[7].Nombre = "Quiche";
            DatosDepartamentos[7].Region = "Centro";

            DatosDepartamentos[8].Id = 3;
            DatosDepartamentos[8].Nombre = "Escuintla";
            DatosDepartamentos[8].Region = "Centro";

            DatosDepartamentos[9].Id = 3;
            DatosDepartamentos[9].Nombre = "Guatemla";
            DatosDepartamentos[9].Region = "Centro";

            DatosDepartamentos[10].Id = 3;
            DatosDepartamentos[10].Nombre = "Huehuetenango";
            DatosDepartamentos[10].Region = "Centro";

            DatosDepartamentos[11].Id = 3;
            DatosDepartamentos[11].Nombre = "Izabal";
            DatosDepartamentos[11].Region = "Centro";

            DatosDepartamentos[12].Id = 3;
            DatosDepartamentos[12].Nombre = "Jalapa";
            DatosDepartamentos[12].Region = "Centro";

            DatosDepartamentos[13].Id = 3;
            DatosDepartamentos[13].Nombre = "Jutiapa";
            DatosDepartamentos[13].Region = "Centro";

            DatosDepartamentos[14].Id = 3;
            DatosDepartamentos[14].Nombre = "Quetzaltenango";
            DatosDepartamentos[14].Region = "Centro";

            DatosDepartamentos[15].Id = 3;
            DatosDepartamentos[15].Nombre = "Retalhuleu";
            DatosDepartamentos[15].Region = "Centro";

            DatosDepartamentos[16].Id = 3;
            DatosDepartamentos[16].Nombre = "Sacatepequez";
            DatosDepartamentos[16].Region = "Centro";

            DatosDepartamentos[17].Id = 3;
            DatosDepartamentos[17].Nombre = "San Marcos";
            DatosDepartamentos[17].Region = "Centro";

            DatosDepartamentos[18].Id = 3;
            DatosDepartamentos[18].Nombre = "Santa Rosa";
            DatosDepartamentos[18].Region = "Centro";

            DatosDepartamentos[19].Id = 3;
            DatosDepartamentos[19].Nombre = "Solola";
            DatosDepartamentos[19].Region = "Centro";

            DatosDepartamentos[20].Id = 3;
            DatosDepartamentos[20].Nombre = "Suchitepequez";
            DatosDepartamentos[20].Region = "Centro";

            DatosDepartamentos[21].Id = 3;
            DatosDepartamentos[21].Nombre = "Totonicapan";
            DatosDepartamentos[21].Region = "Centro";

            DatosDepartamentos[22].Id = 3;
            DatosDepartamentos[22].Nombre = "Zacapa";
            DatosDepartamentos[22].Region = "Centro";

           
        }


    }
}
