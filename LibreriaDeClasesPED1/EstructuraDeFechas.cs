using System;
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
                NodoFecha<T> Nuevo = new NodoFecha<T>();
                Nuevo.Fecha = Fecha;
                Nuevo.Data = Informacion;
                Raiz = Nuevo;
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
                        return 2;
                    }
                }
                else 
                {
                    return InsertarFecha(Nuevo, Padre.Siguiente,Fecha);
                }
            }
        }

        public DateTime FechaPrincipal()
        {
            if (Raiz != null) 
            {
                return Raiz.Fecha;
            }
            else
            {
                DateTime FechaRechazo = Convert.ToDateTime("2000-08-18");
                return FechaRechazo;
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

        public List<T> ListaDeEspera(List<T> Nueva) 
        {
            if (Raiz != null)
            {
                return ListaDeEspera(Nueva, Raiz);
            }
            else 
            {
                return Nueva;
            }
        }

        List<T> ListaDeEspera(List<T> Nueva, NodoFecha<T> Sig) 
        {
            if (Sig != null)
            {
                Nueva.Add(Sig.Data);
                if (Sig.PrimerHijo != null) 
                {
                    Nueva.Add(Sig.PrimerHijo.Data);
                }
                if (Sig.SegundoHijo != null) 
                {
                    Nueva.Add(Sig.SegundoHijo.Data);
                }
                return ListaDeEspera(Nueva,Sig.Siguiente);
            }
            else 
            {
                return Nueva;
            }
        }
    }
}
