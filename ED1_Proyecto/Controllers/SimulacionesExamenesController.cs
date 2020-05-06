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
                SimulacionExamen PruebaContagio = new SimulacionExamen()
                {
                    ViajeEuropa = Convert.ToBoolean(collection["ViajeEuropa"]),
                    ConocidoContagiado = Convert.ToBoolean(collection["ConocidoContagiado"]),
                    FamiliarContagiado = Convert.ToBoolean(collection["FamiliarContagiado"]),
                    ReunionesSociales = Convert.ToBoolean(collection["ReunionesSociales"])

                };
            
                Departamentos Dep = new Departamentos();
                int DepAleatorio = Dep.DepartamentoAleatorio();
                
                int Porcentaje = 5;

                if (PruebaContagio.ViajeEuropa )
                {
                    Porcentaje += 10;
                }
                if (PruebaContagio.ConocidoContagiado)
                {
                    Porcentaje += 15;
                }
                if (PruebaContagio.FamiliarContagiado)
                {
                    Porcentaje += 30;
                }
                if (PruebaContagio.ReunionesSociales)
                {
                    Porcentaje += 5;
                }


                Paciente PacienteSimulado = new Paciente()
                {

                    Edad = rand.Next(0, 80),
                    Nombre = "Nombre" + (DatosPacientesSimulados.Count + 1).ToString(),
                    Apellido = "Apellido" + (DatosPacientesSimulados.Count + 1).ToString(),
                    Identificacion = "Identificacion" + (DatosPacientesSimulados.Count + 1).ToString(),
                    Departamento = Dep.DatosDepartamentos[DepAleatorio].Nombre,
                    Municipio = "Municipio" + (DatosPacientesSimulados.Count + 1).ToString(),

                    Sintomas = "Sintomas" + (DatosPacientesSimulados.Count + 1).ToString(),
                    DescripcionContagioPosible = "Descripcion" + (DatosPacientesSimulados.Count + 1).ToString(),

                    EstadoPaciente = Porcentaje > 34 ? "Confirmado" : "Sospechoso"

                };

                if (PacienteSimulado.EstadoPaciente=="Confirmado" && PacienteSimulado.Edad >60)
                {
                    PacienteSimulado.Prioridad = 1;
                }
                if (PacienteSimulado.EstadoPaciente == "Confirmado" && PacienteSimulado.Edad <1)
                {
                    PacienteSimulado.Prioridad = 2;
                }
                if (PacienteSimulado.EstadoPaciente == "Confirmado" && PacienteSimulado.Edad > 18 && PacienteSimulado.Edad <= 60)
                {
                    PacienteSimulado.Prioridad = 3;
                }

                if (PacienteSimulado.EstadoPaciente == "Sospechoso" && PacienteSimulado.Edad > 60)
                {
                    PacienteSimulado.Prioridad = 4;
                }
                if (PacienteSimulado.EstadoPaciente == "Confirmado" && PacienteSimulado.Edad >=1 && PacienteSimulado.Edad <=18)
                {
                    PacienteSimulado.Prioridad = 5;
                }
                if (PacienteSimulado.EstadoPaciente == "Sospechoso" && PacienteSimulado.Edad <1)
                {
                    PacienteSimulado.Prioridad = 6;
                }
                if (PacienteSimulado.EstadoPaciente == "Sospechoso" && PacienteSimulado.Edad > 18 && PacienteSimulado.Edad <= 60)
                {
                    PacienteSimulado.Prioridad = 7;
                }
                if (PacienteSimulado.EstadoPaciente == "Sospechoso" && PacienteSimulado.Edad >= 1 && PacienteSimulado.Edad <= 18)
                {
                    PacienteSimulado.Prioridad = 8;
                }



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
