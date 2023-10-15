using Microsoft.AspNetCore.Mvc;

namespace StoreSystem.Controllers
{
    public class FacturasController : Controller
    {
        public IActionResult CrearFactura()
        {
            return View();
        }
    }
}
