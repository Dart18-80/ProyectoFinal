﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesPED1
{
    public class EstructuraDeFechas<T> 
    {
        NodoFecha<T> Raiz;

        public int InsertarFecha(T Informacion, DateTime Fecha) 
        {
            if (Raiz == null)
            {
                Raiz.Fecha = Fecha;
                Raiz.Data = Informacion;
                return 1;
            }
            else
            {
                NodoFecha<T> Nuevo = new NodoFecha<T>();
                Nuevo.Data = Informacion;
                return InsertarFecha(Nuevo, Raiz, Fecha);
            }
        }

        int InsertarFecha(NodoFecha<T> Nuevo, NodoFecha<T> Padre, DateTime Fecha) 
        {
            if (Padre == null)
            {
                Padre = Nuevo;
                Padre.Fecha = Fecha;
                return 1;
            }
            else 
            {
                if (Padre.Fecha == Fecha)
                {
                    if (Padre.PrimerHijo == null)
                    {
                        Padre.PrimerHijo = Nuevo;
                        return 1;
                    }
                    else if (Padre.SegundoHijo == null)
                    {
                        Padre.SegundoHijo = Nuevo;
                        return 1;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else 
                {
                    return InsertarFecha(Nuevo, Padre.Siguiente,Fecha);
                }
            }
        }

        public NodoFecha<T> Vacunacion() 
        {
            NodoFecha<T> Nuevo = new NodoFecha<T>();
            NodoFecha<T> Apoyo = new NodoFecha<T>();
            if (Raiz == null)
            {
                return Nuevo;
            }
            else 
            {
                if (Raiz.Siguiente != null)
                {
                    Nuevo = Raiz;
                    Apoyo = Raiz.Siguiente;
                    Raiz = Apoyo;
                    return Nuevo;
                }
                else 
                {
                    Nuevo = Raiz;
                    Raiz = null;
                    return Nuevo;
                }
            }
        }
    }
}
