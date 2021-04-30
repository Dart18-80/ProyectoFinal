using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibreriaDeClasesPED1;
using Proyecto.Models;
namespace Proyecto.Helpers

{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }
        public List<DatosPaciente> ListaParaView = new List<DatosPaciente>();
    }
}
