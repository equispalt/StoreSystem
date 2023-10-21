using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    public class ReportesController : Controller
    {

        private ReporteDatos _ReporteDatos;  // Declarar una instancia de ClienteDatos

        public ReportesController(IConfiguration _configuration)
        {
            _ReporteDatos = new ReporteDatos(_configuration); // Inicializar la instancia en el constructor

        }

        public IActionResult Listar()
        {
            // La vista Mostrara una lista de clientes	
            var oLista = _ReporteDatos.Listar();

            return View(oLista); // Devolver una vista con los datos obtenidos
        }
    }
}
