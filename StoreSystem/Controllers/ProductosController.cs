using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

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

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Productos oProducto)
        {

            var respuesta = _ProductosDatos.Crear(oProducto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idProducto)
        {
            var oProducto = _ProductosDatos.Buscar(idProducto);

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Editar(Productos oProducto)
        {

            var respuesta = _ProductosDatos.Editar(oProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
