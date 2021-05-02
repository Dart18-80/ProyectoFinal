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
        public string Hospital{ get; set; }
        public int Prioridad { get; set; }
        public IFormFile FileC { get; set; }

        public int BuscarPorNombre(DatosPaciente Nombre1, string Nombre2)
        {
            return Nombre1.NombrePaciente.CompareTo(Nombre2);
        }
        public int CompareToNomrbre(DatosPaciente Nombre1, DatosPaciente Nombre2)
        {
            return Nombre1.NombrePaciente.CompareTo(Nombre2.NombrePaciente);
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
