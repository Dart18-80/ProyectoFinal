using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LibreriaDeClasesPED1
{
    public class TablaHash<T> where T : IComparable
    {
        public ListaEnlazada<T>[] ArrayHash;
        public int lenght { get; set; }

        public NodoHash<T> Encontrar;

        public TablaHash(int z)
        {
            ArrayHash = new ListaEnlazada<T>[z];
            int cont = 0;
            while (cont < z)
            {
                ArrayHash[cont] = new ListaEnlazada<T>();
                cont++;
            }
            lenght = z;
        }

        public void AgregarTarea(int posicion, NodoHash<T> valor)
        {
            ArrayHash[posicion].insertarNodo(valor);
        }

        public int FuncionHash(string Nombre, string Apellido, string dpi)
        {
            Char[] cadenaDpi = dpi.ToArray();
            int Sumadpi = 0;
            for (int i = 0; i < cadenaDpi.Length; i++)
            {
                Sumadpi += cadenaDpi[i];
            }
            int indice = (FuncionCadena(Nombre) + FuncionCadena(Apellido) + Sumadpi)%100;
            return indice;
        }
        public int FuncionCadena(string nom)
        {
            Char[] cadena = nom.ToArray();
            int cont = nom.Length;
            int Func = 0;
            for (int i = 0; i < cont; i++)
            {
                switch (cadena[i].ToString())
                {
                    case "A":
                        Func += 1;
                        break;
                    case "B":
                        Func += 2;
                        break;
                    case "C":
                        Func += 3;
                        break;
                    case "D":
                        Func += 4;
                        break;
                    case "E":
                        Func += 5;
                        break;
                    case "F":
                        Func += 6;
                        break;
                    case "G":
                        Func += 7;
                        break;
                    case "H":
                        Func += 8;
                        break;
                    case "I":
                        Func += 9;
                        break;
                    case "J":
                        Func += 10;
                        break;
                    case "K":
                        Func += 11;
                        break;
                    case "L":
                        Func += 12;
                        break;
                    case "M":
                        Func += 13;
                        break;
                    case "N":
                        Func += 14;
                        break;
                    case "Ñ":
                        Func += 15;
                        break;
                    case "O":
                        Func += 16;
                        break;
                    case "P":
                        Func += 17;
                        break;
                    case "Q":
                        Func += 18;
                        break;
                    case "R":
                        Func += 19;
                        break;
                    case "S":
                        Func += 20;
                        break;
                    case "T":
                        Func += 21;
                        break;
                    case "U":
                        Func += 22;
                        break;
                    case "V":
                        Func += 23;
                        break;
                    case "VW":
                        Func += 24;
                        break;
                    case "X":
                        Func += 25;
                        break;
                    case "Y":
                        Func += 26;
                        break;
                    case "Z":
                        Func += 27;
                        break;
                    default:
                        Func += 1;
                        break;
                }
            }

            return Func;
        }

        public NodoHash<T> CrearNodo(T Data)
        {
            NodoHash<T> Nuevo = new NodoHash<T>();
            Nuevo.Data = Data;
            return Nuevo;
        }

        public NodoHash<T> Buscar(string Nombre, string apellido, string dpi, Delegate Condicion)
        {
            int posicion = FuncionHash(Nombre, apellido, dpi);
            return ArrayHash[posicion].Recorrerlista(Nombre, Condicion);
        }
    }
}
