using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class DatosPaciente : IComparable
    {
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string DPIPartidadenacimiento{ get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Trabajo { get; set; }
        public string Enfermedades { get; set; }
        public int Prioridad { get; set; }
        public string EstadoVacunado { get; set; }
        public int BuscarPorDPI(string DP1, DatosPaciente DP12)
        {
            return DP1.CompareTo(DP12.DPIPartidadenacimiento);
        }
        public int CompareToDPI(DatosPaciente DP1, DatosPaciente DP12)
        {
            return DP1.DPIPartidadenacimiento.CompareTo(DP12.DPIPartidadenacimiento);
        }
        public int BuscarPorApellido(string Apellido1, DatosPaciente Apellido2)
        {
            return Apellido1.CompareTo(Apellido2.ApellidoPaciente);
        }
        public int CompareToApellido(DatosPaciente Apellido1, DatosPaciente Apellido2)
        {
            return Apellido1.ApellidoPaciente.CompareTo(Apellido2.ApellidoPaciente);
        }
        public int BuscarPorNombre(string Nombre1, DatosPaciente Nombre2)
        {
            return Nombre1.CompareTo(Nombre2.NombrePaciente);
        }
        public int CompareToNombre(DatosPaciente Nombre1, DatosPaciente Nombre2)
        {
            return Nombre1.NombrePaciente.CompareTo(Nombre2.NombrePaciente);
        }

        public int CompareToPrioridad(DatosPaciente Primero, DatosPaciente Segundo) 
        {
            return Primero.Prioridad.CompareTo(Segundo.Prioridad);
        }
        public int CompareTo(object obj)
        {
            if (Convert.ToInt16(this.CompareTo(obj)) > 0)
                return 1;
            else if (Convert.ToInt16(this.CompareTo(obj)) < 0)
                return -1;
            else
                return 0;
        }
    }
}
