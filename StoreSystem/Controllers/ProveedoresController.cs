using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    public class ProveedoresController : Controller
    {
        public ProveedorDatos _ProveedorDatos;

        public ProveedoresController(IConfiguration _configuration)
        {
            _ProveedorDatos = new ProveedorDatos(_configuration);
        }

        // get: Listar
        public IActionResult Listar()
        {
            var oLista = _ProveedorDatos.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Proveedores oProveedor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = _ProveedorDatos.Crear(oProveedor);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int idProveedor)
        {
            var oProveedor = _ProveedorDatos.Buscar(idProveedor);

            return View(oProveedor);
        }

        [HttpPost]
        public IActionResult Editar(Proveedores oProveedor)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProveedorDatos.Editar(oProveedor);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idProveedor)
        {
            var oProveedor = _ProveedorDatos.Buscar(idProveedor);

            return View(oProveedor);
        }

        [HttpPost]
        public IActionResult Eliminar(Proveedores oProveedor)
        {
            var respuesta = _ProveedorDatos.Eliminar(oProveedor);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
