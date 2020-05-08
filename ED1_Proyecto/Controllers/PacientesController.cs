using ED1_Proyecto.Models;
using System;
using ClassLibrary1.Structures;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ED1_Proyecto.Controllers
{
    public class PacientesController : Controller
    {
        public static int PacienteActual;

        public static List<Paciente> DatosPacientes = new List<Paciente>();
        public static List<Departamentos> DatosDepartamentos = new List<Departamentos>();
        public static List<Hospital> DatosHospital;
        public static List<SimulacionExamen> DatosExamen = new List<SimulacionExamen>();
        public static List<Paciente> DatosPacientesSimulados = new List<Paciente>();

        //Colas 
        private static Cola<string> ColaConfirmados = new Cola<string>();
        private static Cola<string> ColaSospechosos = new Cola<string>();


        //Listas Estados
        public static List<Paciente> PacientesInfectados = new List<Paciente>();
        public static List<Paciente> PacientesSospechosos = new List<Paciente>();

        //Hash
        //public HashTable<int, Hospital> Camas = new HashTable<int, Hospital>();

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(DatosPacientes);
        }

        // GET: SimulacionesExamenes
        public ActionResult ListaExamenes()
        {
            return View(DatosExamen);
        }


        // GET: Pacientes/PacientesConfirmados
        public ActionResult PacientesConfirmados()
        {
            return View(PacientesInfectados);
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: Pacientes/Create
        public ActionResult PruebaCreate()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult PruebaCreate(FormCollection collection)
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
                if (DatosHospital == null)
                {
                    DatosHospital = new List<Hospital>();

                    DatosHospital[1].Ubicacion = "Centro";
                    DatosHospital[1].NumeroCamas = 10;
                    DatosHospital[1].CadenaUnica = DatosHospital[1].Ubicacion + "00";

                    DatosHospital[2].Ubicacion = "Norte";
                    DatosHospital[2].NumeroCamas = 10;
                    DatosHospital[2].CadenaUnica = DatosHospital[2].Ubicacion + "01";

                    DatosHospital[3].Ubicacion = "Sur";
                    DatosHospital[3].NumeroCamas = 10;
                    DatosHospital[3].CadenaUnica = DatosHospital[3].Ubicacion + "02";

                    DatosHospital[4].Ubicacion = "Occidente";
                    DatosHospital[4].NumeroCamas = 10;
                    DatosHospital[4].CadenaUnica = DatosHospital[4].Ubicacion;

                    DatosHospital[5].Ubicacion = "Oriente";
                    DatosHospital[5].NumeroCamas = 10;
                    DatosHospital[5].CadenaUnica = DatosHospital[5].Ubicacion;
                }

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

                //Datos Generales 
                DatosPacientes.Add(AgregarPaciente);

                if (AgregarPaciente.EstadoPaciente == "Confirmado")
                {
                    PacientesInfectados.Add(AgregarPaciente);
                    //Se agragaría a la cola de infectados

                    PacienteActual = PacientesInfectados.Count - 1;
                    ColaConfirmados.Insertar(AgregarPaciente.Identificacion, AgregarPaciente.Prioridad);
                    

                }
                else
                {
                    PacientesSospechosos.Add(AgregarPaciente);
                    ColaSospechosos.Insertar(AgregarPaciente.Identificacion, AgregarPaciente.Prioridad);
                    return RedirectToAction("Create","SimulacionesExamenes",new { id = PacienteActual });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: SimulacionesExamenes/Create
        public ActionResult SimularExamen()
        {
            return View();
        }

        // POST: SimulacionesExamenes/Create
        [HttpPost]
        public ActionResult SimularExamen(FormCollection collection)
        {
            try
            {
               
                var rand = new Random();
                SimulacionExamen PruebaContagio = new SimulacionExamen()
                {
                    ViajeEuropa = collection["ViajeEuropa"]!="false",
                    ConocidoContagiado = collection["ConocidoContagiado"]!="false",
                    FamiliarContagiado = collection["FamiliarContagiado"]!="false",
                    ReunionesSociales = collection["ReunionesSociales"]!="false"

                };

                Departamentos Dep = new Departamentos();
                int DepAleatorio = Dep.DepartamentoAleatorio();

                int Porcentaje = 5;

                if (PruebaContagio.ViajeEuropa)
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

                if (PacienteSimulado.EstadoPaciente == "Confirmado" && PacienteSimulado.Edad > 60)
                {
                    PacienteSimulado.Prioridad = 1;
                }
                if (PacienteSimulado.EstadoPaciente == "Confirmado" && PacienteSimulado.Edad < 1)
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
                if (PacienteSimulado.EstadoPaciente == "Confirmado" && PacienteSimulado.Edad >= 1 && PacienteSimulado.Edad <= 18)
                {
                    PacienteSimulado.Prioridad = 5;
                }
                if (PacienteSimulado.EstadoPaciente == "Sospechoso" && PacienteSimulado.Edad < 1)
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
            catch(Exception x)
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
