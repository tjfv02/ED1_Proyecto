using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Structures
{
    class Nodo<T>
    {
        //Valor
        public T valor { get; set; }

        //Para la cola
        public Nodo<T> siguiente { get; set; }
        public int prioridad { get; set; }

        //Para el arbol 
        public Nodo<T> Padre;
        public Nodo<T> Izquierdo;
        public Nodo<T> Derecho;
    }
}
