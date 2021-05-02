﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class ColaEstructura<T> where T : IComparable
    {
        NodeEstructuras<T> Primero;
        public NodeEstructuras<T> CrearEstructura(string Nombre, T Data)
        {
            NodeEstructuras<T> Nuevo = new NodeEstructuras<T>();
            Nuevo.Estructura = Data;
            Nuevo.NombreHospital = Nombre;
            return Nuevo;
        }

        public void Encolar(NodeEstructuras<T> Nuevo)
        {
            if (Primero == null)
            {
                Primero = Nuevo;
            }
            else
            {
                Encolar(Primero, Nuevo);
            }
        }
        void Encolar(NodeEstructuras<T> Raiz, NodeEstructuras<T> Nuevo)
        {
            if (Raiz.Siguiente == null)
            {
                Raiz.Siguiente = Nuevo;
            }
            else
            {
                Encolar(Raiz.Siguiente, Nuevo);
            }
        }

        public T RetornarEstructura(string NombreU)
        {
            if (Primero == null)
            {
                return default;
            }
            else
            {
                return RetornarEstructura(NombreU, Primero);
            }
        }

        T RetornarEstructura(string NombreU, NodeEstructuras<T> Raiz)
        {
            if (Raiz == null)
            {
                return default;
            }
            else
            {
                if (Raiz.NombreHospital == NombreU)
                {
                    return Raiz.Estructura;
                }
                else
                {
                    return RetornarEstructura(NombreU, Raiz.Siguiente);
                }
            }
        }

        public T RetornarUsuarios(int i)
        {
            if (i == 1)
            {
                return Primero.Estructura;
            }
            else
            {
                return RetornarUsuarios(i, Primero);
            }
        }

        T RetornarUsuarios(int i, NodeEstructuras<T> Raiz)
        {
            if (i == 1)
            {
                return Raiz.Estructura;
            }
            else
            {
                if (Raiz.Siguiente != null)
                {
                    return RetornarUsuarios(i - 1, Raiz.Siguiente);
                }
                else
                {
                    return Raiz.Estructura;
                }
            }
        }
    }
}
