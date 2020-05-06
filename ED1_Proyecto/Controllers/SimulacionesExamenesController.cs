using ED1_Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ED1_Proyecto.Controllers
{
    public class SimulacionesExamenesController : Controller
    {
        public static List<SimulacionExamen> DatosExamen = new List<SimulacionExamen>();
        public static List<Paciente> DatosPacientesSimulados = new List<Paciente>();

        // GET: SimulacionesExamenes
        public ActionResult Index()
        {
            return View(DatosExamen);
        }

        // GET: SimulacionesExamenes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SimulacionesExamenes/Create
        public ActionResult Create2()
        {
            return View();
        }

        // POST: SimulacionesExamenes/Create
        [HttpPost]
        public ActionResult Create2(FormCollection collection)
        {
            try
            {
                var rand = new Random();

                Paciente PacienteSimulado = new Paciente()
                {

                    Edad = rand.Next(80),
                    Nombre = "Nombre" + (DatosPacientesSimulados.Count + 1).ToString(),
                    Apellido = "Apellido" + (DatosPacientesSimulados.Count + 1).ToString(),
                    Identificacion="Identificacion"+(DatosPacientesSimulados.Count + 1).ToString(),
                    Departamento = "Departamento" + (DatosPacientesSimulados.Count + 1).ToString(),
                    Municipio ="Municipio" + (DatosPacientesSimulados.Count + 1).ToString(),

                    Sintomas = "Sintomas" + (DatosPacientesSimulados.Count + 1).ToString(),
                    DescripcionContagioPosible = "Descripcion" + (DatosPacientesSimulados.Count + 1).ToString(),

                    

                };

                SimulacionExamen PruebaContagio = new SimulacionExamen()
                {
                    ViajeEuropa = Convert.ToBoolean(collection["ViajeEuropa"]),
                    ConocidoContagiado = Convert.ToBoolean(collection["ConocidoContagiado"]),
                    FamiliarContagiado = Convert.ToBoolean(collection["FamiliarContagiado"]),
                    ReunionesSociales = Convert.ToBoolean(collection["ReunionesSociales"])

                };



                DatosExamen.Add(PruebaContagio);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SimulacionesExamenes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SimulacionesExamenes/Edit/5
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

        // GET: SimulacionesExamenes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SimulacionesExamenes/Delete/5
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
