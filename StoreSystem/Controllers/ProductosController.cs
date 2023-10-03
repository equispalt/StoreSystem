using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System;

namespace StoreSystem.Controllers
{
    public class ProductosController : Controller
    {
        public ProductosDatos _ProductosDatos;
        public DatosDTO _DatosDTOProv;
        public DatosDTO _DatosDTOCat;

        public ProductosController(IConfiguration _configuration) 
        {
            _ProductosDatos = new ProductosDatos(_configuration);    
            _DatosDTOProv = new DatosDTO(_configuration); 
            _DatosDTOCat  = new DatosDTO(_configuration);
        }

        public IActionResult Listar()
        {
            var oLista = _ProductosDatos.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            var LProveedores = _DatosDTOProv.ListarProveedores();
            var LCategorias  = _DatosDTOCat.ListarCategorias();

            ViewBag.oProveedores = LProveedores;
            ViewBag.oCategorias = LCategorias;

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
            

            var LProveedores = _DatosDTOProv.ListarProveedores();
            var LCategorias  = _DatosDTOCat.ListarCategorias();

            ViewBag.oProveedores = LProveedores;
            ViewBag.oCategorias = LCategorias;

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

        public IActionResult Eliminar(int idProducto)
        {
            var oProducto = _ProductosDatos.Buscar(idProducto);

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Productos oProducto)
        {
            var respuesta = _ProductosDatos.Eliminar(oProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


    }
}
