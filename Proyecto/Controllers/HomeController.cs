using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto.Models;
using System.Text.RegularExpressions;

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

            return RedirectToAction("CrearCita");
        }
        public IActionResult CrearCita()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
