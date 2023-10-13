using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;

namespace StoreSystem.Controllers
{
    public class PrecioProductosController : Controller
    {
        public PrecioProductosDatos _PrecioProductosDatos;
        public PrecioProductosController(IConfiguration _configuration)
        {
            _PrecioProductosDatos = new PrecioProductosDatos(_configuration);
        }
        public IActionResult Listar()
        {
            var oLista = _PrecioProductosDatos.Listar();   
            return View(oLista);
        }
    }
}
