using System;
using System.Collections.Generic;

namespace LibreriaDeClasesPED1
{
    public class ColaPrioridad<T> where T : IComparable
    {
        NodoPrioridad<T> Primero;
        NodoPrioridad<T> Ultimo;


        public void InsertQueue(T Nuevo)
        {
            NodoPrioridad<T> Estruct = new NodoPrioridad<T>();
            Estruct.Data = Nuevo;
            if (Primero == null)
            {
                Primero = Estruct;
                Estruct.Arriba = null;
                Ultimo = Estruct;
            }
            else
            {
                InsertQueu(Estruct, Primero);
            }
        }

        void InsertQueu(NodoPrioridad<T> Nuevo, NodoPrioridad<T> Raiz)
        {
            if (Raiz.Derecha == null || Raiz.Izquierda == null)
            {
                if (Raiz.Izquierda == null)
                {
                    Raiz.Siguiente = Nuevo;
                    Raiz.Izquierda = Nuevo;
                    Nuevo.Arriba = Raiz;
                    Ultimo = Nuevo;
                }
                else
                {
                    Raiz.Siguiente.Siguiente = Nuevo;
                    Raiz.Derecha = Nuevo;
                    Nuevo.Arriba = Raiz;
                    Ultimo = Nuevo;
                }
            }
            else
            {
                InsertQueu(Nuevo, Raiz.Siguiente);
            }
        }

        public void HeapSort(Delegate Condicion)
        {
            if (Primero == null)
            {
                return;
            }
            else
            {
                HeapSort(Primero, Condicion);
            }
        }

        void HeapSort(NodoPrioridad<T> Siguiente, Delegate Condicion)
        {
            if (Siguiente != null)
            {
                if (Siguiente.Derecha != null && Siguiente.Izquierda != null)
                {
                    int IzquierdaDerecha = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Izquierda.Data, Siguiente.Derecha.Data));
                    if (IzquierdaDerecha > 0)
                    {
                        int PadreDerecha = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Data, Siguiente.Derecha.Data));
                        if (PadreDerecha > 0)
                        {
                            T Almacenar;
                            Almacenar = Siguiente.Data;
                            Siguiente.Data = Siguiente.Derecha.Data;
                            Siguiente.Derecha.Data = Almacenar;
                            HeapSort(Condicion);
                        }
                        else
                        {
                            HeapSort(Siguiente.Siguiente, Condicion);
                        }
                    }
                    else if (IzquierdaDerecha < 0)
                    {
                        int PadreIzquierda = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Data, Siguiente.Izquierda.Data));
                        if (PadreIzquierda > 0)
                        {
                            T Almacenar;
                            Almacenar = Siguiente.Data;
                            Siguiente.Data = Siguiente.Izquierda.Data;
                            Siguiente.Izquierda.Data = Almacenar;
                            HeapSort(Condicion);
                        }
                        else
                        {
                            HeapSort(Siguiente.Siguiente, Condicion);
                        }
                    }
                }
                else if (Siguiente.Izquierda != null)
                {
                    int PadreIzquierda = Convert.ToInt32(Condicion.DynamicInvoke(Siguiente.Data, Siguiente.Izquierda.Data));
                    if (PadreIzquierda > 0)
                    {
                        T Almacenar;
                        Almacenar = Siguiente.Data;
                        Siguiente.Data = Siguiente.Izquierda.Data;
                        Siguiente.Izquierda.Data = Almacenar;
                        HeapSort(Condicion);
                    }
                    else
                    {
                        HeapSort(Siguiente.Siguiente, Condicion);
                    }
                }
                else
                {
                    return;
                }

            }
            else
            {
                return;
            }
        }

        public T returnNode(Delegate Condicion)
        {
            T Aux = Primero.Data;
            Primero.Data = Ultimo.Data;
            if (Primero.Siguiente != null)
            {
                Delete(Primero, Primero.Siguiente, Condicion);
            }
            else
            {
                Primero = null;
                Ultimo = null;
            }
            return Aux;
        }
        void Delete(NodoPrioridad<T> Raiz, NodoPrioridad<T> Sig, Delegate Condicion)
        {
            if (Sig != null)
            {
                if (Raiz.Siguiente.Siguiente != null)
                {
                    Delete(Raiz.Siguiente, Sig.Siguiente, Condicion);
                }
                else
                {
                    Ultimo = Raiz;
                    Raiz.Siguiente = null;
                }
            }
            else
            {

            }
        }

        public List<T> Tareas()
        {
            List<T> Nueva = new List<T>();
            if (Primero != null)
            {
                return Tareas(Primero, Primero.Siguiente, Nueva);
            }
            else
            {
                return default;
            }
        }

        List<T> Tareas(NodoPrioridad<T> Raiz, NodoPrioridad<T> Sig, List<T> Nueva)
        {
            if (Sig == null)
            {
                Nueva.Add(Raiz.Data);
                return Nueva;
            }
            else
            {
                Nueva.Add(Raiz.Data);
                return Tareas(Raiz.Siguiente, Sig.Siguiente, Nueva);
            }
        }

    }
}
