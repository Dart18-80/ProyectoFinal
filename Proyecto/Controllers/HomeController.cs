using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using Proyecto.Helpers;

namespace Proyecto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()//Menu del Programa
        {
            return View();
        }
        public IActionResult CrearPaciente()//Creacion e ingreso de datos del usuario
        {
            return View();
        }
        [HttpPost]
        public IActionResult CrearPaciente(IFormCollection collection)
        {
            var NuevoPaciente = new Models.DatosPaciente { 
            NombrePaciente=Regex.Replace(collection["NombrePaciente"], @"\s", "").ToUpper(),
            ApellidoPaciente= Regex.Replace(collection["ApellidoPaciente"], @"\s", "").ToUpper(),
            DPIPartidadenacimiento = Convert.ToInt32(Regex.Replace(collection["DPIPartidadenacimiento"], @"\s", "")),
            Edad= Convert.ToInt32(Regex.Replace(collection["Edad"], @"\s", "")),
            Departamento= Regex.Replace(collection["Departamento"], @"\s", "").ToUpper(),
            };
            Singleton.Instance.ListaParaView.Add(NuevoPaciente);
            return RedirectToAction("CrearCita");
        }
        public IActionResult CrearCita()
        {
            if (Singleton.Instance.ListaParaView[0].Departamento=="ALTAVERAPAZ")
            {
                ViewData["MUN1"] = "Chahal";
                ViewData["MUN2"] = "Chisec";
                ViewData["MUN3"] = "Cobán";
                ViewData["MUN4"] = "Fray Bartolomé de las Casas";
                ViewData["MUN5"] = "La Tinta";
                ViewData["MUN6"] = "Lanquín";
                ViewData["MUN7"] = "Panzós";
                ViewData["MUN8"] = "Raxruhá";
                ViewData["MUN9"] = "San Cristóbal Verapaz";
                ViewData["MUN10"] = "San Juan Chamelco";
                ViewData["MUN11"] = "San Pedro Carchá";
                ViewData["MUN12"] = "Santa Cruz Verapaz";
                ViewData["MUN13"] = "Santa María Cahabón";
                ViewData["MUN14"] = "Senahú";
                ViewData["MUN15"] = "Tamahú";
                ViewData["MUN16"] = "Tactic";
                ViewData["MUN17"] = "Tucurú";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "BAJAVERAPAZ")
            {
                ViewData["MUN1"] = "Cubulco";
                ViewData["MUN2"] = "Granados";
                ViewData["MUN3"] = "Purulhá";
                ViewData["MUN4"] = "Rabinal";
                ViewData["MUN5"] = "Salama";
                ViewData["MUN6"] = "San Jerónimo";
                ViewData["MUN7"] = "San Miguel Chicaj";
                ViewData["MUN8"] = "Santa Cruz el Chol";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Chimaltenango".ToUpper())
            {
                ViewData["MUN1"] = "Acatenango";
                ViewData["MUN2"] = "Chimaltenango";
                ViewData["MUN3"] = "El Tejar";
                ViewData["MUN4"] = "Parramos";
                ViewData["MUN5"] = "Patzicía";
                ViewData["MUN6"] = "Patzún";
                ViewData["MUN7"] = "Pochuta";
                ViewData["MUN8"] = "San Andrés Itzapa";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Chiquimula".ToUpper())
            {
                ViewData["MUN1"] = "Camotán";
                ViewData["MUN2"] = "Chiquimula";
                ViewData["MUN3"] = "Concepción Las Minas";
                ViewData["MUN4"] = "Esquipulas";
                ViewData["MUN5"] = "Ipala";
                ViewData["MUN6"] = "Jocotán";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "ElProgreso".ToUpper())
            {
                ViewData["MUN1"] = "El Jícaro";
                ViewData["MUN2"] = "Guastatoya";
                ViewData["MUN3"] = "Morazán";
                ViewData["MUN4"] = "San Agustín Acasaguastlán";
                ViewData["MUN5"] = "San Antonio La Paz";
                ViewData["MUN6"] = "San Cristóbal Acasaguastlán";
                ViewData["MUN7"] = "Sanarate";
                ViewData["MUN8"] = "Sansare";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Escuintla".ToUpper())
            {
                ViewData["MUN1"] = "Escuintla";
                ViewData["MUN2"] = "Guanagazapa";
                ViewData["MUN3"] = "Iztapa";
                ViewData["MUN4"] = "La Democracia";
                ViewData["MUN5"] = "La Gomera";
                ViewData["MUN6"] = "Masagua";
                ViewData["MUN7"] = "Nueva Concepción";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Guatemala".ToUpper())
            {
                ViewData["MUN1"] = "Amatitlán";
                ViewData["MUN2"] = "Chinautla";
                ViewData["MUN3"] = "Chuarrancho";
                ViewData["MUN4"] = "Ciudad de Guatemala";
                ViewData["MUN5"] = "Fraijanes";
                ViewData["MUN6"] = "Mixco";
                ViewData["MUN7"] = "Palencia";
                ViewData["MUN8"] = "San José del Golfo";
                ViewData["MUN9"] = "San José Pinula";
                ViewData["MUN10"] = "San Juan Sacatepéquez";
                ViewData["MUN11"] = "San Miguel Petapa";
                ViewData["MUN12"] = "San Pedro Ayampuc";
                ViewData["MUN13"] = "San Pedro Sacatepéquez";
                ViewData["MUN14"] = "San Raymundo";
                ViewData["MUN15"] = "Santa Catarina Pinula";
                ViewData["MUN16"] = "Villa Canales";
                ViewData["MUN17"] = "Villa Nueva";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Huehuetenango".ToUpper())
            {

                ViewData["MUN1"] = "Aguacatán";
                ViewData["MUN2"] = "Chiantla";
                ViewData["MUN3"] = "Colotenango";
                ViewData["MUN4"] = "Concepción Huista";
                ViewData["MUN5"] = "Cuilco";
                ViewData["MUN6"] = "Huehuetenango";
                ViewData["MUN7"] = "Jacaltenango";
                ViewData["MUN8"] = "La Democracia";
                ViewData["MUN9"] = "La Libertad";
                ViewData["MUN10"] = "Malacatancito";
                ViewData["MUN11"] = "Nentón";
                ViewData["MUN12"] = "Petatán";
                ViewData["MUN13"] = "San Antonio Huista";
                ViewData["MUN14"] = "San Gaspar Ixchil";
                ViewData["MUN15"] = "San Ildefonso Ixtahuacán";
                ViewData["MUN16"] = "San Juan Atitán";
                ViewData["MUN17"] = "San Juan Ixcoy";
                ViewData["MUN18"] = "San Mateo Ixtatán";
                ViewData["MUN19"] = "San Miguel Acatán";
                ViewData["MUN20"] = "San Pedro Nécta";
                ViewData["MUN21"] = "San Pedro Soloma";
                ViewData["MUN22"] = "San Rafael La Independencia";
                ViewData["MUN23"] = "San Rafael Pétzal";
                ViewData["MUN24"] = "San Sebastián Coatán";
                ViewData["MUN25"] = "San Sebastián Huehuetenango";
                ViewData["MUN26"] = "Santa Ana Huista";
                ViewData["MUN27"] = "Santa Bárbara";
                ViewData["MUN28"] = "Santa Cruz Barillas";
                ViewData["MUN29"] = "Santa Eulalia";
                ViewData["MUN30"] = "Santiago Chimaltenango";
                ViewData["MUN31"] = "Tectitán";
                ViewData["MUN32"] = "Todos Santos Cuchumatán";
                ViewData["MUN33"] = "Unión Cantinil";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "IZABAL")
            {
                ViewData["MUN1"] = "El Estor";
                ViewData["MUN2"] = "Livingston";
                ViewData["MUN3"] = "Los Amates";
                ViewData["MUN4"] = "Morales";
                ViewData["MUN5"] = "Puerto Barrios";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "JALAPA")
            {
                ViewData["MUN1"] = "Jalapa";
                ViewData["MUN2"] = "Mataquescuintla";
                ViewData["MUN3"] = "Monjas";
                ViewData["MUN4"] = "San Carlos Alzatate";
                ViewData["MUN5"] = "San Luis Jilotepeque";
                ViewData["MUN6"] = "San Manuel Chaparrón";
                ViewData["MUN7"] = "San Pedro Pinula";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "JUTIAPA")
            {
                ViewData["MUN1"] = "Agua Blanca";
                ViewData["MUN2"] = "Asunción Mita";
                ViewData["MUN3"] = "Atescatempa";
                ViewData["MUN4"] = "Comapa";
                ViewData["MUN5"] = "Conguaco";
                ViewData["MUN6"] = "El Adelanto";
                ViewData["MUN7"] = "El Progreso";
                ViewData["MUN8"] = "Jalpatagua";
                ViewData["MUN9"] = "Jerez";
                ViewData["MUN10"] = "Jutiapa";
                ViewData["MUN11"] = "Moyuta";
                ViewData["MUN12"] = "Pasaco";
                ViewData["MUN13"] = "Quesada";
                ViewData["MUN14"] = "San José Acatempa";
                ViewData["MUN15"] = "Santa Catarina Mita";
                ViewData["MUN16"] = "Yupiltepeque";
                ViewData["MUN17"] = "Zapotitlán";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Petén".ToUpper())
            {
                ViewData["MUN1"] = "Dolores";
                ViewData["MUN2"] = "El Chal";
                ViewData["MUN3"] = "Isla de Flores";
                ViewData["MUN4"] = "La Libertad";
                ViewData["MUN5"] = "Las Cruces";
                ViewData["MUN6"] = "Melchor de Mencos";
                ViewData["MUN7"] = "Poptún";
                ViewData["MUN8"] = "San Andres";
                ViewData["MUN9"] = "San Benito";
                ViewData["MUN10"] = "San Francisco";
                ViewData["MUN11"] = "San José";
                ViewData["MUN12"] = "San Luis";
                ViewData["MUN13"] = "Santa Ana";
                ViewData["MUN14"] = "Sayaxché";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Quetzaltenango".ToUpper())
            {
                ViewData["MUN1"] = "Almolonga";
                ViewData["MUN2"] = "Cabricán";
                ViewData["MUN3"] = "Cajolá";
                ViewData["MUN4"] = "Cantel";
                ViewData["MUN5"] = "Coatepeque";
                ViewData["MUN6"] = "Colomba Costa Cuca";
                ViewData["MUN7"] = "Concepción Chiquirichapa";
                ViewData["MUN8"] = "El Palmar";
                ViewData["MUN9"] = "Flores Costa Cuca";
                ViewData["MUN10"] = "Génova";
                ViewData["MUN11"] = "Huitán";
                ViewData["MUN12"] = "La Esperanza";
                ViewData["MUN13"] = "Olintepeque";
                ViewData["MUN14"] = "Palestina de Los Altos";
                ViewData["MUN15"] = "Quetzaltenango";
                ViewData["MUN16"] = "Salcajá";
                ViewData["MUN17"] = "San Carlos Sija";
                ViewData["MUN18"] = "San Francisco La Unión";
                ViewData["MUN19"] = "San Juan Ostuncalco";
                ViewData["MUN20"] = "San Martín Sacatepéquez";
                ViewData["MUN21"] = "San Mateo";
                ViewData["MUN22"] = "San Miguel Sigüilá";
                ViewData["MUN23"] = "Sibilia";
                ViewData["MUN24"] = "Zunil";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Quiché".ToUpper())
            {
                ViewData["MUN1"] = "Canillá";
                ViewData["MUN2"] = "Chajul";
                ViewData["MUN3"] = "Chicamán";
                ViewData["MUN4"] = "Chiché";
                ViewData["MUN5"] = "Santo Tomás Chichicastenango";
                ViewData["MUN6"] = "Chinique";
                ViewData["MUN7"] = "Cunén";
                ViewData["MUN8"] = "Ixcán";
                ViewData["MUN9"] = "Joyabaj";
                ViewData["MUN10"] = "Nebaj";
                ViewData["MUN11"] = "Pachalum";
                ViewData["MUN12"] = "Patzité";
                ViewData["MUN13"] = "Sacapulas";
                ViewData["MUN14"] = "San Andrés Sajcabajá";
                ViewData["MUN15"] = "San Antonio Ilotenango";
                ViewData["MUN16"] = "San Bartolomé Jocotenango";
                ViewData["MUN17"] = "San Juan Cotzal";
                ViewData["MUN18"] = "San Pedro Jocopilas";
                ViewData["MUN19"] = "Santa Cruz del Quiche";
                ViewData["MUN20"] = "Uspantán";
                ViewData["MUN21"] = "Zacualpa";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Retalhuleu".ToUpper())
            {
                ViewData["MUN1"] = "Champerico";
                ViewData["MUN2"] = "El Asintal";
                ViewData["MUN3"] = "Nuevo San Carlos";
                ViewData["MUN4"] = "Retalhuleu";
                ViewData["MUN5"] = "San Andres Villa Seca";
                ViewData["MUN6"] = "San Felipe";
                ViewData["MUN7"] = "San Martín Zapotitlán";
                ViewData["MUN8"] = "San Sebastián";
                ViewData["MUN9"] = "Santa Cruz Muluá";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Sacatepéquez".ToUpper())
            {
                ViewData["MUN1"] = "Alotenango";
                ViewData["MUN2"] = "Ciudad Vieja";
                ViewData["MUN3"] = "Jocotenango";
                ViewData["MUN4"] = "Antigua Guatemala";
                ViewData["MUN5"] = "Magdalena Milpas Altas";
                ViewData["MUN6"] = "Pastores";
                ViewData["MUN7"] = "San Antonio Aguas Calientes";
                ViewData["MUN8"] = "San Bartolomé Milpas Altas";
                ViewData["MUN9"] = "San Lucas Sacatepéquez";
                ViewData["MUN10"] = "San Miguel Dueñas";
                ViewData["MUN11"] = "Santa Catarina Barahona";
                ViewData["MUN12"] = "Santa Lucía Milpas Altas";
                ViewData["MUN13"] = "Santa María de Jesús";
                ViewData["MUN14"] = "Santiago Sacatepéquez";
                ViewData["MUN15"] = "Santo Domingo Xenacoj";
                ViewData["MUN16"] = "Sumpango";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "SANMARCOS")
            {
                ViewData["MUN1"] = "Ayutla";
                ViewData["MUN2"] = "Catarina";
                ViewData["MUN3"] = "Comitancillo";
                ViewData["MUN4"] = "Concepción Tutuapa";
                ViewData["MUN5"] = "El Quetzal";
                ViewData["MUN6"] = "El Tumbador";
                ViewData["MUN7"] = "Esquipulas Palo Gordo";
                ViewData["MUN8"] = "Ixchiguán";
                ViewData["MUN9"] = "La Blanca";
                ViewData["MUN10"] = "La Reforma";
                ViewData["MUN11"] = "Malacatán";
                ViewData["MUN12"] = "Nuevo Progreso";
                ViewData["MUN13"] = "Ocós";
                ViewData["MUN14"] = "Pajapita";
                ViewData["MUN15"] = "Río Blanco";
                ViewData["MUN16"] = "San Antonio Sacatepéquez";
                ViewData["MUN17"] = "San Cristóbal Cucho";
                ViewData["MUN18"] = "San José El Rodeo";
                ViewData["MUN19"] = "San José Ojetenam";
                ViewData["MUN20"] = "San Lorenzo";
                ViewData["MUN21"] = "San Marcos";
                ViewData["MUN22"] = "San Miguel Ixtahuacán";
                ViewData["MUN23"] = "San Pablo";
                ViewData["MUN24"] = "San Pedro Sacatepéquez";
                ViewData["MUN25"] = "San Rafael Pie de la Cuesta";
                ViewData["MUN26"] = "Sibinal";
                ViewData["MUN27"] = "Sipacapa";
                ViewData["MUN28"] = "Tacaná";
                ViewData["MUN29"] = "Tajumulco";
                ViewData["MUN30"] = "Tejutla";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "SANTAROSA")
            {
                ViewData["MUN1"] = "Barberena";
                ViewData["MUN2"] = "Casillas";
                ViewData["MUN3"] = "Chiquimulilla";
                ViewData["MUN4"] = "Cuilapa";
                ViewData["MUN5"] = "Guazacapán";
                ViewData["MUN6"] = "Nueva Santa Rosa";
                ViewData["MUN7"] = "Oratorio";
                ViewData["MUN8"] = "Pueblo Nuevo Viñas";
                ViewData["MUN9"] = "San Juan Tecuaco";
                ViewData["MUN10"] = "San Rafael las Flores";
                ViewData["MUN11"] = "Santa Cruz Naranjo";
                ViewData["MUN12"] = "Santa María Ixhuatán";
                ViewData["MUN13"] = "Santa Rosa de Lima";
                ViewData["MUN14"] = "Taxisco";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Sololá".ToUpper())
            {
                ViewData["MUN1"] = "Concepción";
                ViewData["MUN2"] = "Nahualá";
                ViewData["MUN3"] = "Panajachel";
                ViewData["MUN4"] = "San Andrés Semetabaj";
                ViewData["MUN5"] = "San Antonio Palopó";
                ViewData["MUN6"] = "San José Chacayá";
                ViewData["MUN7"] = "San Juan La Laguna";
                ViewData["MUN8"] = "San Lucas Tolimán";
                ViewData["MUN9"] = "San Marcos La Laguna";
                ViewData["MUN10"] = "San Pablo La Laguna";
                ViewData["MUN11"] = "San Pedro La Laguna";
                ViewData["MUN12"] = "Santa Catarina Ixtahuacán";
                ViewData["MUN13"] = "Santa Catarina Palopó";
                ViewData["MUN14"] = "Santa Clara La Laguna";
                ViewData["MUN15"] = "Santa Cruz La Laguna";
                ViewData["MUN16"] = "Santa Lucía Utatlán";
                ViewData["MUN17"] = "Santa María Visitación";
                ViewData["MUN18"] = "Santiago Atitlán";
                ViewData["MUN19 "] = "Solola";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Suchitepéquez".ToUpper())
            {
                ViewData["MUN1"] = "Chicacao";
                ViewData["MUN2"] = "Cuyotenango";
                ViewData["MUN3"] = "Mazatenango";
                ViewData["MUN4"] = "Patulul";
                ViewData["MUN5"] = "Pueblo Nuevo";
                ViewData["MUN6"] = "Río Bravo";
                ViewData["MUN7"] = "Samayac";
                ViewData["MUN8"] = "San Antonio Suchitepéquez";
                ViewData["MUN9"] = "San Bernardino";
                ViewData["MUN10"] = "San Francisco Zapotitlán";
                ViewData["MUN11"] = "San Gabriel";
                ViewData["MUN12"] = "San José El Ídolo";
                ViewData["MUN13"] = "San José La Máquina";
                ViewData["MUN14"] = "San Juan Bautista";
                ViewData["MUN15"] = "San Lorenzo";
                ViewData["MUN16"] = "San Miguel Panán";
                ViewData["MUN17"] = "San Pablo Jocopilas";
                ViewData["MUN18"] = "Santa Bárbara";
                ViewData["MUN19"] = "Santo Domingo Suchitepéquez";
                ViewData["MUN20"] = "Santo Tomás La Unión";
                ViewData["MUN21"] = "Zunilito";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Totonicapán".ToUpper())
            {
                ViewData["MUN1"] = "Momostenango";
                ViewData["MUN2"] = "San Andrés Xecul";
                ViewData["MUN3"] = "San Bartolo";
                ViewData["MUN4"] = "San Cristóbal Totonicapán";
                ViewData["MUN5"] = "San Francisco El Alto";
                ViewData["MUN6"] = "Santa Lucía La Reforma";
                ViewData["MUN7"] = "Santa María Chiquimula";
                ViewData["MUN8"] = "Totonicapán";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "ZACAPA".ToUpper())
            {
                ViewData["MUN1"] = "Cabañas";
                ViewData["MUN2"] = "Estanzuela";
                ViewData["MUN3"] = "Gualán";
                ViewData["MUN4"] = "Huité";
                ViewData["MUN5"] = "La Unión";
                ViewData["MUN6"] = "Río Hondo";
                ViewData["MUN7"] = "San Diego";
                ViewData["MUN8"] = "San Jorge";
                ViewData["MUN9"] = "Teculután";
                ViewData["MUN10"] = "Usumatlán";
                ViewData["MUN11"] = "Zacapa";
            }
            return View();
        }
        [HttpPost]
        public IActionResult CrearCita(IFormCollection collection)
        {

            var NuevaCrearCita = new Models.DatosPaciente {
                NombrePaciente = Singleton.Instance.ListaParaView[0].NombrePaciente,
                ApellidoPaciente = Singleton.Instance.ListaParaView[0].ApellidoPaciente,
                DPIPartidadenacimiento = Singleton.Instance.ListaParaView[0].DPIPartidadenacimiento,
                Edad = Singleton.Instance.ListaParaView[0].Edad,
                Departamento = Singleton.Instance.ListaParaView[0].Departamento,
                Enfermedades = Regex.Replace(collection["Enfermedades"], @"\s", ""),
                Municipio = Regex.Replace(collection["Municipio"], @"\s", "").ToUpper(),
                Prioridad = 0
            };
            Singleton.Instance.ListaParaView.Clear();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
