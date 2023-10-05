using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    public class ExistenciasController : Controller
    {
        public ExistenciasDatos _existenciaDatos;

        public ExistenciasController(IConfiguration _configuration)
        {
            _existenciaDatos = new ExistenciasDatos(_configuration);
        }

        public IActionResult MostrarExistencias()
        {
            var oLista = _existenciaDatos.Listar();
            return View(oLista);
        }
    }
}
