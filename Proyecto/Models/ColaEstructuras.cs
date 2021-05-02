using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Proyecto.Models
{
    public class ColaEstructura<T> where T : IComparable
    {
        NodeEstructuras<T> Primero;
        public NodeEstructuras<T> CrearEstructura(string Nombre, T Data, T ArbolAVL)
        {
            NodeEstructuras<T> Nuevo = new NodeEstructuras<T>();
            Nuevo.EstructuraPrioridadPrincipal = Data;
            Nuevo.ArbolAVLHospital = ArbolAVL;
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

        public T RetornarEstructuraPrioridad(string NombreU)
        {
            if (Primero == null)
            {
                return default;
            }
            else
            {
                return RetornarEstructuraPrioridad(NombreU, Primero);
            }
        }

        T RetornarEstructuraPrioridad(string NombreU, NodeEstructuras<T> Raiz)
        {
            if (Raiz == null)
            {
                return default;
            }
            else
            {
                if (Raiz.NombreHospital == NombreU)
                {
                    return Raiz.EstructuraPrioridadPrincipal;
                }
                else
                {
                    return RetornarEstructuraPrioridad(NombreU, Raiz.Siguiente);
                }
            }
        }

        public T RetornarArbolAvl(string NombreU)
        {
            if (Primero == null)
            {
                return default;
            }
            else
            {
                return RetornarArbolAvl(NombreU, Primero);
            }
        }

        T RetornarArbolAvl(string NombreU, NodeEstructuras<T> Raiz)
        {
            if (Raiz == null)
            {
                return default;
            }
            else
            {
                if (Raiz.NombreHospital == NombreU)
                {
                    return Raiz.ArbolAVLHospital;
                }
                else
                {
                    return RetornarArbolAvl(NombreU, Raiz.Siguiente);
                }
            }
        }

    }
}
