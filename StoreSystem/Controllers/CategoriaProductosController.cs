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
        public IActionResult Crear() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CategoriaProductos oCategoriaProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _CategoriaProductosDatos.Crear(oCategoriaProductos);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }


        public IActionResult Editar(int idCategoriaProducto)
        {
            var oCategoriaProductos = _CategoriaProductosDatos.Buscar(idCategoriaProducto);

            return View(oCategoriaProductos);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaProductos oCategoriaProductos)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _CategoriaProductosDatos.Editar(oCategoriaProductos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idCategoriaProducto)
        {
            var oCategoriaProductos = _CategoriaProductosDatos.Buscar(idCategoriaProducto);

            return View(oCategoriaProductos);
        }

        [HttpPost]
        public IActionResult Eliminar(CategoriaProductos oCategoriaProductos)
        {
            var respuesta = _CategoriaProductosDatos.Eliminar(oCategoriaProductos);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }




    }
}
