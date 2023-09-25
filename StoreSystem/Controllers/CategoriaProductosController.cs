using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    public class CategoriaProductosController : Controller
    {
        private CategoriaProductosDatos _CategoriaProductosDatos;

        public CategoriaProductosController(IConfiguration _configuration)
        {
            _CategoriaProductosDatos = new CategoriaProductosDatos(_configuration);
        }
        public IActionResult Listar()
        {
            var oLista = _CategoriaProductosDatos.Listar();  

            return View(oLista);
        }
    }
}
