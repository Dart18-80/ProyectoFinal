using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class NodeEstructuras<T>
    {
        public T Estructura { get; set; }
        public NodeEstructuras<T> Siguiente { get; set; }
        public string NombreHospital { get; set; }
    }
}
