using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesPED1
{
    public class NodoFecha <T>
    {
        public DateTime Fecha { get; set; }
        public T Data { get; set; }
        public NodoFecha<T> PrimerHijo { get; set; }
        public NodoFecha<T> SegundoHijo { get; set; }
        public NodoFecha<T> Siguiente { get; set; }
    }
}
