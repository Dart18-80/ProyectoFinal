using System;

namespace LibreriaDeClasesPED1
{
    public class ArbolBinario<T> where T : IComparable
    {
        public NodoPrioridad<T> Raiz;

        public NodoPrioridad<T> EnviarRaiz() 
        {
            return Raiz;
        }

        public ArbolBinario()
        {
            Raiz = null;
        }
        public void RaízC()
        {
            Raiz = null;
        }
        public void Insertar(T nMedicina, Delegate Comparacion)
        {
            NodoPrioridad<T> nuevo = new NodoPrioridad<T>();
            nuevo.Data = nMedicina;
            nuevo.Izquierda = null;
            nuevo.Derecha = null;
            nuevo.Padre = null;
            nuevo.Altura = 1;
            if (Raiz == null)
                Raiz = nuevo;
            else
            {
                Insertar(nuevo, Raiz, Comparacion);
            }


        }
        public void Insertar(NodoPrioridad<T> nuevo, NodoPrioridad<T> n, Delegate Comparacion)
        {
            if (n != null)
            {
                int compar = Convert.ToInt16(Comparacion.DynamicInvoke(nuevo.Data, n.Data));
                if (compar == 0)
                {

                }
                else if (compar > 0)
                {
                    if (n.Derecha != null)
                    {
                        Insertar(nuevo, n.Derecha, Comparacion);
                        n.Altura = Mayor(n.Derecha, n.Izquierda) + 1;
                    }
                    else
                    {
                        n.Derecha = nuevo;
                        nuevo.Padre = n;
                        n.Altura = Mayor(n.Derecha, n.Izquierda) + 1;
                    }
                }
                else
                {
                    if (n.Izquierda != null)
                    {
                        Insertar(nuevo, n.Izquierda, Comparacion);
                        n.Altura = Mayor(n.Derecha, n.Izquierda) + 1;
                    }
                    else
                    {
                        n.Izquierda = nuevo;
                        nuevo.Padre = n;
                        n.Altura = Mayor(n.Derecha, n.Izquierda) + 1;
                    }
                }
            }
            int balanceo = Balanceo(n);
            if (balanceo > 1)
            {
                balanceo = Balanceo(n.Derecha);
                if (balanceo == -1)
                {
                    RotacionDer(n.Derecha);
                }
                RotacionIzq(n);
            }
            else if (balanceo < -1)
            {
                balanceo = Balanceo(n.Izquierda);
                if (balanceo == 1)
                {
                    RotacionIzq(n.Izquierda);
                }
                RotacionDer(n);
            }

        }

        public int Balanceo(NodoPrioridad<T> N)
        {
            if (N.Derecha != null && N.Izquierda != null)
            {
                return (N.Derecha.Altura - N.Izquierda.Altura);
            }
            else if (N.Derecha != null)
            {
                return N.Derecha.Altura;
            }
            else if (N.Izquierda != null)
            {
                return 0 - N.Izquierda.Altura;
            }
            else
            {
                return 0;
            }
        }
        public int Mayor(NodoPrioridad<T> a, NodoPrioridad<T> b)
        {
            if (a != null && b != null)
            {
                if (a.Altura > b.Altura)
                {
                    return (a.Altura);
                }
                else
                {
                    return (b.Altura);
                }
            }
            else if (a != null)
            {
                return (a.Altura);
            }
            else if (b != null)
            {
                return (b.Altura);
            }
            else
            {
                return 0;
            }
        }
        public T Buscar(string nBuscar, NodoPrioridad<T> N, Delegate Comparacion)
        {
            T Nuevo;
            int Verificacion = Convert.ToInt16(Comparacion.DynamicInvoke(nBuscar, N.Data));
            if (Verificacion != 0)
            {
                int compar = Convert.ToInt16(Comparacion.DynamicInvoke(nBuscar, N.Data));
                if (compar < 0)
                {
                    if (Raiz.Izquierda != null)
                    {
                        Nuevo = Buscar(nBuscar, Raiz.Izquierda, Comparacion);
                        return Nuevo;
                    }
                    else
                    {
                        return default;
                    }
                }
                else
                {
                    if (Raiz.Derecha != null)
                    {
                        Nuevo = Buscar(nBuscar, Raiz.Derecha, Comparacion);
                        return Nuevo;
                    }
                    else
                    {
                        return default;
                    }
                }
            }
            else
            {
                Nuevo = N.Data;
                return Nuevo;
            }
        }
        public T Buscar(string nBuscar, Delegate Comparacion)
        {
            T Nuevo;
            int Verificacion = Convert.ToInt16(Comparacion.DynamicInvoke(nBuscar, Raiz.Data));
            if (Verificacion != 0)
            {
                int compar = Convert.ToInt16(Comparacion.DynamicInvoke(nBuscar, Raiz.Data));
                if (compar < 0)
                {
                    if (Raiz.Izquierda != null)
                    {
                        Nuevo = Buscar(nBuscar, Raiz.Izquierda, Comparacion);
                        return Nuevo;
                    }
                    else 
                    {
                        return default;
                    }
                }
                else 
                {
                    if (Raiz.Derecha != null)
                    {
                        Nuevo = Buscar(nBuscar, Raiz.Derecha, Comparacion);
                        return Nuevo;
                    }
                    else 
                    {
                        return default;
                    }
                }
            }
            else
            {
                Nuevo = Raiz.Data;
                return Nuevo;
            }
        }

        public void Eliminar(T nEliminar, NodoPrioridad<T> n, Delegate Comparacion)
        {
            int compar = Convert.ToInt16(Comparacion.DynamicInvoke(nEliminar, n.Data));
            if (compar == 0)
            {
                Eliminar(n);
            }
            else if (compar < 0)
            {
                if (n.Izquierda != null)
                {
                    Eliminar(nEliminar, n.Izquierda, Comparacion);
                }
            }
            else
            {
                if (n.Derecha != null)
                {
                    Eliminar(nEliminar, n.Derecha, Comparacion);
                }
            }
            int balanceo = Balanceo(n);
            if (balanceo > 1)
            {
                balanceo = Balanceo(n.Derecha);
                if (balanceo == -1)
                {
                    RotacionDer(n.Derecha);
                }
                RotacionIzq(n);
            }
            else if (balanceo < -1)
            {
                balanceo = Balanceo(n.Izquierda);
                if (balanceo == 1)
                {
                    RotacionIzq(n.Izquierda);
                }
                RotacionDer(n);
            }

        }
        public void Eliminar(NodoPrioridad<T> N)
        {
            if (N.Derecha == null && N.Izquierda == null)
            {
                if (N.Padre.Derecha == N)
                {
                    N.Padre.Derecha = null;
                }
                else
                {
                    N.Padre.Izquierda = null;
                }
            }
            else if (N.Derecha != null && N.Izquierda != null)
            {
                NodoPrioridad<T> Masizq = MIzquierda(N);
                if (N.Padre == null)
                {
                    Raiz = Masizq;
                    Masizq.Derecha = N.Derecha;
                }
                else
                {
                    if (N.Padre.Derecha == N)
                    {
                        N.Padre.Derecha = Masizq;
                        Masizq.Derecha = N.Derecha;
                    }
                    else
                    {
                        N.Padre.Izquierda = Masizq;
                        Masizq.Derecha = N.Derecha;
                    }
                }
            }
            else if (N.Derecha != null)
            {
                if (N.Padre.Derecha == N)
                {
                    N.Padre.Derecha = N.Derecha;
                }
                else
                {
                    N.Padre.Izquierda = N.Derecha;
                }
            }
            else
            {
                if (N.Padre.Derecha == N)
                {
                    N.Padre.Derecha = N.Izquierda;
                }
                else
                {
                    N.Padre.Izquierda = N.Izquierda;
                }
            }
        }
        public NodoPrioridad<T> MIzquierda(NodoPrioridad<T> N)
        {
            if (N.Izquierda == null)
            {
                Eliminar(N);
                return N;
            }
            else
            {
                return MIzquierda(N.Izquierda);
            }
        }


        public void RotacionIzq(NodoPrioridad<T> N)
        {
            if (N.Padre != null)
            {
                bool Pder;
                if (N.Padre.Derecha == N)
                {
                    Pder = true;
                    N.Padre.Derecha = N.Derecha;
                }
                else
                {
                    Pder = false;
                    N.Padre.Izquierda = N.Derecha;
                }
                N.Derecha.Padre = N.Padre;
                N.Derecha = N.Derecha.Izquierda;
                if (N.Derecha != null)
                {
                    N.Derecha.Padre = N;
                }
                if (Pder)
                {
                    N.Padre.Derecha.Izquierda = N;
                    N.Padre = N.Padre.Derecha;
                }
                else
                {
                    N.Padre.Izquierda.Izquierda = N;
                    N.Padre = N.Padre.Izquierda;
                }
            }
            else
            {
                N.Derecha.Padre = N.Padre;
                N.Padre = N.Derecha;
                N.Derecha = N.Derecha.Izquierda;
                N.Padre.Izquierda = N;
                if (N.Derecha != null)
                    N.Derecha.Padre = N;
                if (N == Raiz)
                    Raiz = N.Padre;
            }
            N.Altura = Mayor(N.Izquierda, N.Derecha) + 1;
            N.Padre.Altura = Mayor(N.Padre.Izquierda, N.Padre.Derecha) + 1;
        }
        public void RotacionDer(NodoPrioridad<T> N)
        {
            if (N.Padre != null)
            {
                bool Pder;
                if (N.Padre.Derecha == N)
                {
                    Pder = true;
                    N.Padre.Derecha = N.Izquierda;
                }
                else
                {
                    Pder = false;
                    N.Padre.Izquierda = N.Izquierda;
                }
                N.Izquierda.Padre = N.Padre;
                N.Izquierda = N.Izquierda.Derecha;
                if (N.Izquierda != null)
                {
                    N.Izquierda.Padre = N;
                }
                if (Pder)
                {
                    N.Padre.Derecha.Derecha = N;
                    N.Padre = N.Padre.Derecha;
                }
                else
                {
                    N.Padre.Izquierda.Derecha = N;
                    N.Padre = N.Padre.Izquierda;
                }
            }
            else
            {
                N.Izquierda.Padre = N.Padre;
                N.Padre = N.Izquierda;
                N.Izquierda = N.Izquierda.Derecha;
                N.Padre.Derecha = N;
                if (N.Izquierda != null)
                    N.Izquierda.Padre = N;
                if (N == Raiz)
                    Raiz = N.Padre;
            }
            N.Altura = Mayor(N.Izquierda, N.Derecha) + 1;
            N.Padre.Altura = Mayor(N.Padre.Izquierda, N.Padre.Derecha) + 1; ;
        }
    }
}
