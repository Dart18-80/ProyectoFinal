﻿using System;

namespace LibreriaDeClasesPED1
{
    public class NodoPrioridad<T> where T : IComparable
    {
        public T Data { get; set; }
        public NodoPrioridad<T> Derecha { get; set; }
        public NodoPrioridad<T> Izquierda { get; set; }
        public NodoPrioridad<T> Siguiente { get; set; }
        public NodoPrioridad<T> Padre { get; set; }
        public NodoPrioridad<T> Arriba { get; set; }
        public int Altura { get; set; }
        public int Index { get; set; }
    }
}
