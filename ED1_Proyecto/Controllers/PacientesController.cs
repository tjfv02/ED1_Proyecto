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
        Nodo<string> nodo;

        public static int PacienteActual;

        public static List<SimulacionCama> Camas = new List<SimulacionCama>();

        public static List<Paciente> DatosPacientes = new List<Paciente>();
        public static List<Paciente> DatosPacientesSimulados = new List<Paciente>();
        public static List<Departamentos> DatosDepartamentos = new List<Departamentos>();
        public static List<Hospital> DatosHospital;
        public static List<SimulacionExamen> DatosExamen = new List<SimulacionExamen>();

        //Colas 
        private static Cola<string> ColaConfirmados = new Cola<string>();
        private static Cola<string> ColaSospechosos = new Cola<string>();


        //Listas Estados
        public static List<Paciente> PacientesInfectados = new List<Paciente>();
        public static List<Paciente> PacientesSospechosos = new List<Paciente>();



        //Hash
        public static HashTable<string, Paciente> CamasCentro = new HashTable<string, Paciente>();
        public static HashTable<string, Paciente> CamasNorte = new HashTable<string, Paciente>();
        public static HashTable<string, Paciente> CamasSur = new HashTable<string, Paciente>();
        public static HashTable<string, Paciente> CamasOriente = new HashTable<string, Paciente>();
        public static HashTable<string, Paciente> CamasOccidente = new HashTable<string, Paciente>();

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(DatosPacientes);
        }

        // GET: Pacientes
        public ActionResult PacientesConfirmados()
        {
            return View(PacientesInfectados);
        }

        // GET: Pacientes
        public ActionResult PacientesNoConfirmados()
        {
            return View(PacientesSospechosos);
        }

        // GET: SimulacionesExamenes
        public ActionResult ListaExamenes()
        {
            return View(DatosExamen);
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
                if (DatosHospital == null)
                {
                    DatosHospital = new List<Hospital>();

                    DatosHospital.Add(new Hospital()
                    {

                        Ubicacion = "Centro",
                        NumeroCamas = 10
                    });
                    DatosHospital[DatosHospital.Count - 1].CadenaUnica = DatosHospital[DatosHospital.Count - 1].Ubicacion;

                    
                    DatosHospital.Add(new Hospital()
                    {
                    Ubicacion = "Norte",
                    NumeroCamas = 10
                    

                    });
                    DatosHospital[DatosHospital.Count - 1].CadenaUnica = DatosHospital[DatosHospital.Count - 1].Ubicacion;

                    DatosHospital.Add(new Hospital()
                    {
                        Ubicacion = "Sur",
                        NumeroCamas = 10

                    });
                    DatosHospital[DatosHospital.Count - 1].CadenaUnica = DatosHospital[DatosHospital.Count - 1].Ubicacion;

                    DatosHospital.Add(new Hospital()
                    {
                        Ubicacion = "Occidente",
                        NumeroCamas = 10
                        

                    });
                    DatosHospital[DatosHospital.Count - 1].CadenaUnica = DatosHospital[DatosHospital.Count - 1].Ubicacion;

                    DatosHospital.Add(new Hospital()
                    {
                        Ubicacion = "Oriente",
                        NumeroCamas = 10
                        

                    });
                    DatosHospital[DatosHospital.Count - 1].CadenaUnica = DatosHospital[DatosHospital.Count - 1].Ubicacion;


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
                    DescripcionContagioPosible = collection["DescripcionContagioPosible"],
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
                    //PacientesSospechosos.Add(AgregarPaciente);
                    ColaSospechosos.Insertar(AgregarPaciente.Identificacion, AgregarPaciente.Prioridad);
                    return RedirectToAction("SimularExamen");
                }

                return RedirectToAction("Index");
            }
            catch (Exception E)
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
                LlenandoDepartamentos();
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


                Paciente PacienteSimulado = DatosPacientes[DatosPacientes.Count - 1];

                PacienteSimulado.EstadoPaciente = Porcentaje > 34 ? "Confirmado" : "Sospechoso";

                //Paciente PacienteSimulado = new Paciente()
                //{

                //    Edad = rand.Next(0, 80),
                //    Nombre = "Nombre" + (DatosPacientesSimulados.Count + 1).ToString(),
                //    Apellido = "Apellido" + (DatosPacientesSimulados.Count + 1).ToString(),
                //    Identificacion = "Identificacion" + (DatosPacientesSimulados.Count + 1).ToString(),
                //    Departamento = Dep.DatosDepartamentos[DepAleatorio].Nombre,
                //    Municipio = "Municipio" + (DatosPacientesSimulados.Count + 1).ToString(),

                //    Sintomas = "Sintomas" + (DatosPacientesSimulados.Count + 1).ToString(),
                //    DescripcionContagioPosible = "Descripcion" + (DatosPacientesSimulados.Count + 1).ToString(),

                //    EstadoPaciente = Porcentaje > 34 ? "Confirmado" : "Sospechoso"

                //};

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

                if (PacienteSimulado.EstadoPaciente =="Sospechoso")
                {
                    ColaSospechosos.Eliminar();
                    DatosPacientes[DatosPacientes.Count - 1].EstadoPaciente = "Sano";
                    PacientesSospechosos.Add(DatosPacientes[DatosPacientes.Count - 1]);
                }

                if (PacienteSimulado.EstadoPaciente == "Confirmado")
                {
                    PacientesInfectados.Add(DatosPacientes[DatosPacientes.Count - 1]);
                    //return RedirectToAction("AsignarCama");
                }


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
                Paciente Eliminado = new Paciente()
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
                    DescripcionContagioPosible = collection["DescripcionContagioPosible"],
                    Fecha = collection["Fecha"],
                    HoraIngreso = collection["HoraIngreso"],
                    EstadoPaciente = collection["EstadoPaciente"]

                };
                DatosPacientes.Remove(Eliminado);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Estadisticas()
        {
            int NumConfirmados = PacientesInfectados.Count - 1;
            int NumSospechosos = PacientesSospechosos.Count - 1;
            int PorcentajeSospechosos = (PacientesSospechosos.Count - 1 * 100) / DatosPacientes.Count - 1;

            return View();
        }
        
       public ActionResult AsignarCama()
        {
          
            for (int i = 0; i < DatosDepartamentos.Count-1; i++)
            {
                if (PacientesInfectados[PacientesInfectados.Count - 1].Departamento==DatosDepartamentos[i].Nombre)
                {
                    //asignar region al paciente 


                    if (DatosDepartamentos[i].Region=="Centro")
                    {
                        CamasCentro.Insertar(PacientesInfectados[PacientesInfectados.Count - 1].Identificacion, PacientesInfectados[PacientesInfectados.Count - 1]);
                        PacientesInfectados[PacientesInfectados.Count - 1].HospitalAsignado = "Centro";
                        DatosPacientes[DatosPacientes.Count - 1].HospitalAsignado = "Centro";
                    }
                    if (DatosDepartamentos[i].Region == "Norte")
                    {
                        CamasNorte.Insertar(PacientesInfectados[PacientesInfectados.Count - 1].Identificacion, PacientesInfectados[PacientesInfectados.Count - 1]);
                        PacientesInfectados[PacientesInfectados.Count - 1].HospitalAsignado = "Norte";
                        DatosPacientes[DatosPacientes.Count - 1].HospitalAsignado = "Norte";
                    }
                    if (DatosDepartamentos[i].Region == "Sur")
                    {
                        CamasSur.Insertar(PacientesInfectados[PacientesInfectados.Count - 1].Identificacion, PacientesInfectados[PacientesInfectados.Count - 1]);
                        PacientesInfectados[PacientesInfectados.Count - 1].HospitalAsignado = "Sur";
                        DatosPacientes[DatosPacientes.Count - 1].HospitalAsignado = "Sur";
                    }
                    if (DatosDepartamentos[i].Region == "Oriente")
                    {
                        CamasOriente.Insertar(PacientesInfectados[PacientesInfectados.Count - 1].Identificacion, PacientesInfectados[PacientesInfectados.Count - 1]);
                        PacientesInfectados[PacientesInfectados.Count - 1].HospitalAsignado = "Oriente";
                        DatosPacientes[DatosPacientes.Count - 1].HospitalAsignado = "Oriente";
                    }
                    if (DatosDepartamentos[i].Region == "Occidente")
                    {
                        CamasOccidente.Insertar(PacientesInfectados[PacientesInfectados.Count - 1].Identificacion, PacientesInfectados[PacientesInfectados.Count - 1]);
                        PacientesInfectados[PacientesInfectados.Count - 1].HospitalAsignado = "Occidente";
                        DatosPacientes[DatosPacientes.Count - 1].HospitalAsignado = "Occidente";
                    }
                }
            }
           
            return View();
        }
        public void LlenandoDepartamentos()
        {

            DatosDepartamentos.Add(new Departamentos()
            {
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
            DatosDepartamentos.Add(new Departamentos()
            {
                Id = 22,
                Nombre = "Zacapa",
                Region = "Oriente"

            });






        }

    }
}
