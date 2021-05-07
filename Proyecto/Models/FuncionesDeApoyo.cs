using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proyecto.Helpers;

namespace Proyecto.Models
{
    public class FuncionesDeApoyo
    {
        public int Menor(int Edad, int Enfermedad, int Trabajo) 
        {
            if (Edad < Enfermedad)
            {
                if (Edad < Trabajo)
                {
                    return Edad;
                }
                else
                {
                    return Trabajo;
                }
            }
            else 
            {
                if (Enfermedad < Trabajo)
                {
                    return Enfermedad;
                }
                else 
                {
                    return Trabajo;
                }
            }
        }

        public DateTime FechaParaAsignar() 
        {
            if (Singleton.Instance.Contador <= 2 && Singleton.Instance.Contador >= 0 )
            {
                Singleton.Instance.Contador++;
                return Singleton.Instance.Global;
            }
            else if (Singleton.Instance.Contador <= 5 && Singleton.Instance.Contador >= 3 )
            {
                Singleton.Instance.Contador++;
                return Singleton.Instance.Global;
            }
            else if (Singleton.Instance.Contador <= 8 && Singleton.Instance.Contador >= 6)
            {
                Singleton.Instance.Contador++;
                return Singleton.Instance.Global;
            }
            else if (Singleton.Instance.Contador == 9)
            {
                Singleton.Instance.Contador = 1;
                Singleton.Instance.Global.AddDays(1);
                return Singleton.Instance.Global;
            }
            else
            {
                DateTime FechaRechazo = Convert.ToDateTime("2000-08-18");
                return FechaRechazo;
            }

        }
    }
}
