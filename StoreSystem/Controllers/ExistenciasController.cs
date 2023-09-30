using Microsoft.AspNetCore.Mvc;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    public class ExistenciasController : Controller
    {
        public IActionResult MostrarExistencias()
        {
            return View();
        }
    }
}
