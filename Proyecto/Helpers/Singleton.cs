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
        public int VerificacionHospitales;
        public TablaHash<DatosPaciente> TablaHashPacientes = new TablaHash<DatosPaciente>(100);
        public ArbolBinario<DatosPaciente> AccesoArbol = new ArbolBinario<DatosPaciente>();
        public List<DatosPaciente> ListaParaView = new List<DatosPaciente>();
        public List<DatosPaciente> ListaParaBusquedasAVL = new List<DatosPaciente>();
        public List<string> ListaParaCrearMunicipios = new List<string>();
        public ColaEstructura<ColaPrioridad<DatosPaciente>> HospitalesColas = new ColaEstructura<ColaPrioridad<DatosPaciente>>();
        public ColaEstructura<ArbolBinario<DatosPaciente>> BusquedadHospitales = new ColaEstructura<ArbolBinario<DatosPaciente>>();

    }
}
