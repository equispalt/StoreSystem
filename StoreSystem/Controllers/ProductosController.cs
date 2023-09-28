using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;

namespace StoreSystem.Controllers
{
    public class ProductosController : Controller
    {
        public ProductosDatos _ProductosDatos;

        public ProductosController(IConfiguration _configuration) 
        {
            _ProductosDatos = new ProductosDatos(_configuration);
        }

        public IActionResult Listar()
        {
            var oLista = _ProductosDatos.Listar();
            return View(oLista);
        }
    }
}
