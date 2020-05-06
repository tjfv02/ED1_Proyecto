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
        //List
        public static List<Paciente> DatosPacientes = new List<Paciente>();




        // GET: Pacientes
        public ActionResult ListaPacientes()
        {
            return View(DatosPacientes);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pacientes/Create
        public ActionResult IngresoPacientes()
        {
            return View();
        }

        // POST: Pacientes/Create
        [HttpPost]
        public ActionResult IngresoPacientes(FormCollection collection)
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

                return RedirectToAction("ListaPacientes");
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
