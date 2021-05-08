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
        // Variable de creacion de hospitales 
        public int VerificacionHospitales;

        // Creacion de Hash General 
        public TablaHash<DatosPaciente> TablaHashPacientes = new TablaHash<DatosPaciente>(100);

        //Creacion de Arbol para busquedas generales 
        public ArbolBinario<DatosPaciente> AccesoArbol = new ArbolBinario<DatosPaciente>();
        public ArbolBinario<DatosPaciente> ArbolGeneralApellido = new ArbolBinario<DatosPaciente>();
        public ArbolBinario<DatosPaciente> ArbolGeneralDPI = new ArbolBinario<DatosPaciente>();

        // Listas para almacenar informacion entre vistas
        public List<DatosPaciente> ListaParaView = new List<DatosPaciente>();
        public List<DatosPaciente> ListaParaBusquedasAVL = new List<DatosPaciente>();
        public List<DatosPaciente> ListaMuesraPrimerosCola = new List<DatosPaciente>();
        public List<DatosPaciente> ListadePacientesParaV = new List<DatosPaciente>();
        public List<DatosPaciente> ListaParaFechas = new List<DatosPaciente>();
        public List<DatosPaciente> Listacamasvacunacion = new List<DatosPaciente>();
        public List<DatosPaciente> ListadoVacunados = new List<DatosPaciente>();

        // Llamado de las estructuras que guardar los hospitales
        public ColaEstructura<ColaPrioridad<DatosPaciente>> HospitalesColas = new ColaEstructura<ColaPrioridad<DatosPaciente>>();
        public ColaEstructura<ArbolBinario<DatosPaciente>> BusquedadHospitales = new ColaEstructura<ArbolBinario<DatosPaciente>>();
        public ColaEstructura<ArbolBinario<DatosPaciente>> BusquedadHospitalDPI = new ColaEstructura<ArbolBinario<DatosPaciente>>();
        public ColaEstructura<ArbolBinario<DatosPaciente>> BusquedadHospitalApellido = new ColaEstructura<ArbolBinario<DatosPaciente>>();
        public ColaEstructura<EstructuraDeFechas<DatosPaciente>> EstructuraParaCitas = new ColaEstructura<EstructuraDeFechas<DatosPaciente>>();

        //Inicio de Fecha 
        public DateTime Global = Convert.ToDateTime("2021-05-8");
        public int Contador;
    }
}
