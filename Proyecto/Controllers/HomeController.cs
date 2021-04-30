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
            DPI = Regex.Replace(collection["DPI"], @"\s", ""),
            PartidaDeNacimiento= collection["PartidaDeNacimiento"],
            Departamento= Regex.Replace(collection["Departamento"], @"\s", "").ToUpper(),
            Municipio = Regex.Replace(collection["Municipio"], @"\s", "").ToUpper()
            };
            Singleton.Instance.ListaParaView.Add(NuevoPaciente);
            return RedirectToAction("CrearCita");
        }
        public IActionResult CrearCita()
        {
            if (Singleton.Instance.ListaParaView[0].Departamento=="ALTAVERAPAZ")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "BAJAVERAPAZ")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Baja Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Chimaltenango".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Chimaltenango";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Chiquimula".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "ElProgreso".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Escuintla".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Guatemala".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Huehuetenango".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "IZABAL")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "JALAPA")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "JUTIAPA")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Petén".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Quetzaltenango".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Quiché".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Retalhuleu".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Sacatepéquez".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "SANMARCOS")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "SANTAROSA")
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Sololá".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Suchitepéquez".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "Totonicapán".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            else if (Singleton.Instance.ListaParaView[0].Departamento == "ZACAPA".ToUpper())
            {
                ViewData["HOSPITAL1"] = "Hospital central de Alta Verapaz";
                ViewData["HOSPITAL2"] = "Hospital Rural de Alta Verapaz";
            }
            return View();
        }
        [HttpPost]
        public IActionResult CrearCita(IFormCollection collection)
        {
            var NuevaCrearCita = new Models.DatosPaciente { 

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
