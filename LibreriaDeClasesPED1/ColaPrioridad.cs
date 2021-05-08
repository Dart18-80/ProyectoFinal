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
                InsertarNuevoSiguiente(Estruct,Primero);
            }
        }

        void InsertarNuevoSiguiente(NodoPrioridad<T> Nuevo, NodoPrioridad<T> Raiz) 
        {
            if (Raiz != null) 
            {
                if (Raiz.Siguiente == null)
                {
                    Raiz.Siguiente = Nuevo;
                    Ultimo = Nuevo;
                }
                else 
                {
                    InsertarNuevoSiguiente(Nuevo,Raiz.Siguiente);
                }
            }
        }

        void InsertQueu(NodoPrioridad<T> Nuevo, NodoPrioridad<T> Raiz)
        {
            if (Raiz.Derecha == null || Raiz.Izquierda == null)
            {
                if (Raiz.Izquierda == null)
                {
                    Raiz.Izquierda = Nuevo;
                    Nuevo.Arriba = Raiz;
                }
                else 
                {
                    Raiz.Derecha = Nuevo;
                    Nuevo.Arriba = Raiz;
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

        public T returnNode(Delegate Condicion, T Default)
        {
            if (Primero != null)
            {
                T Apoyo = Primero.Data;
                Primero.Data = Ultimo.Data;
                if (Primero.Siguiente == null)
                {
                    int Comparacion = Convert.ToInt32(Condicion.DynamicInvoke(Primero.Siguiente.Data, Primero.Data));
                    if (Comparacion == 0)
                    {
                        int Compa = Convert.ToInt32(Condicion.DynamicInvoke(Primero.Izquierda.Data, Primero.Data));
                        if (Compa == 0)
                        {
                            Primero.Izquierda = null;
                            Primero.Siguiente = null;
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        int Cont = Convert.ToInt32(Condicion.DynamicInvoke(Primero.Derecha.Data, Primero.Data));
                        if (Cont == 0)
                        {
                            Primero.Derecha = null;
                            Primero.Izquierda.Siguiente = null;
                        }
                        else
                        {
                            Delete(Primero, Primero.Siguiente, Condicion);
                        }
                    }
                }
                else 
                {
                    Primero = null;
                    Ultimo = null;
                }
                BuscarValorUltimo(Primero);
                return Apoyo;
            }
            else 
            {
                return Default;
            }
        }

        void BuscarValorUltimo(NodoPrioridad<T> Raiz)
        {
            if (Raiz != null)
            {
                if (Raiz.Siguiente == null)
                {
                    Ultimo = Raiz;
                }
                else
                {
                    BuscarValorUltimo(Raiz.Siguiente);
                }
            }
        }
        void Delete(NodoPrioridad<T> Raiz, NodoPrioridad<T> Sig, Delegate Condicion)
        {
            if (Sig != null) 
            {
                int Comparacion = Convert.ToInt32(Condicion.DynamicInvoke(Sig.Izquierda.Data, Raiz.Data));
                if (Comparacion == 0) 
                {
                    BuscarEliminar(Raiz, Sig, Condicion);
                    Sig.Izquierda = null;
                }
                else 
                {
                    int Compa = Convert.ToInt32(Condicion.DynamicInvoke(Sig.Derecha.Data, Raiz.Data));
                    if (Compa == 0)
                    {
                        BuscarEliminar(Raiz,Sig,Condicion);
                        Sig.Derecha = null;
                    }
                    else 
                    {
                        Delete(Raiz,Sig.Siguiente,Condicion);
                    }
                }
            }
        }

        void BuscarEliminar(NodoPrioridad<T> Raiz, NodoPrioridad<T> Sig, Delegate Condicion) 
        {
            int Comparar = Convert.ToInt32(Condicion.DynamicInvoke(Sig.Siguiente.Data, Raiz.Data));
            if (Comparar == 0)
            {
                Sig.Siguiente = null;
            }
            else 
            {
                BuscarEliminar(Raiz,Sig.Siguiente,Condicion);
            }
        }
    }
}
