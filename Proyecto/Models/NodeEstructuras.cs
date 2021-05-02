using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class NodeEstructuras<T> where T: IComparable
    {
        public T EstructuraPrioridadPrincipal { get; set; }
        public T ArbolAVLHospital { get; set; }
        public NodeEstructuras<T> Siguiente { get; set; }
        public string NombreHospital { get; set; }
    }
}
