using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriaDeClasesPED1
{
    public class ListaEnlazada<T> where T : IComparable
    {
        public NodoHash<T>[] lista { get; set; }

        public ListaEnlazada()
        {
            lista = null;
        }

        public void insertarNodo(NodoHash<T> valor)
        {

            if (lista == null)
            {
                lista = new NodoHash<T>[1];
                lista[0] = new NodoHash<T>();
                lista[0] = valor;
            }
            else
            {
                NodoHash<T>[] temporal = lista;
                lista = new NodoHash<T>[temporal.Length + 1];
                int cont = 0;
                while (cont < temporal.Length)
                {
                    lista[cont] = temporal[cont];
                    cont++;
                }
                lista[cont] = valor;

            }
        }
        public NodoHash<T> Recorrerlista(string ValTitulo, Delegate Condicion)
        {
            int cont = 0;

            while ((cont <= lista.Length) && (Convert.ToInt16(Condicion.DynamicInvoke(lista[cont].Data, ValTitulo)) != 0))
            {
                cont++;
            }
            if (cont == lista.Length)
            {
                return null;
            }
            else
            {
                return lista[cont];
            }
        }
    }
}
