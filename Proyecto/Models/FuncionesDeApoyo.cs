using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
