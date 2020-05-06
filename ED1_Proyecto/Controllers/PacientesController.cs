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
                    Fecha = collection["Fecha"],
                    HoraIngreso = collection["HoraIngreso"],
                    EstadoPaciente = collection["EstadoPaciente"]


                };
                //Definicion de Prioridad 
                if (AgregarPaciente.EstadoPaciente == "Confirmado" && AgregarPaciente.Edad > 60)
                {
                    AgregarPaciente.Prioridad = 1;
                }
                if (AgregarPaciente.EstadoPaciente == "Confirmado" && AgregarPaciente.Edad < 1)
                {
                    AgregarPaciente.Prioridad = 2;
                }
                if (AgregarPaciente.EstadoPaciente == "Confirmado" && AgregarPaciente.Edad > 18 && AgregarPaciente.Edad <= 60)
                {
                    AgregarPaciente.Prioridad = 3;
                }

                if (AgregarPaciente.EstadoPaciente == "Sospechoso" && AgregarPaciente.Edad > 60)
                {
                    AgregarPaciente.Prioridad = 4;
                }
                if (AgregarPaciente.EstadoPaciente == "Confirmado" && AgregarPaciente.Edad >= 1 && AgregarPaciente.Edad <= 18)
                {
                    AgregarPaciente.Prioridad = 5;
                }
                if (AgregarPaciente.EstadoPaciente == "Sospechoso" && AgregarPaciente.Edad < 1)
                {
                    AgregarPaciente.Prioridad = 6;
                }
                if (AgregarPaciente.EstadoPaciente == "Sospechoso" && AgregarPaciente.Edad > 18 && AgregarPaciente.Edad <= 60)
                {
                    AgregarPaciente.Prioridad = 7;
                }
                if (AgregarPaciente.EstadoPaciente == "Sospechoso" && AgregarPaciente.Edad >= 1 && AgregarPaciente.Edad <= 18)
                {
                    AgregarPaciente.Prioridad = 8;
                }

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

        
       


    }
}
