using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;

namespace StoreSystem.Controllers
{
    public class CajaController : Controller
    {
        public CajaDatos _CajaDatos;

        public CajaController(IConfiguration _configuration)
        {
            _CajaDatos = new CajaDatos(_configuration);
        }
        public IActionResult estados()
        {
            var oLista = _CajaDatos.Estados();
            return View(oLista);
        }
    }
}
