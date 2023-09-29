using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
    public class ProductosController : Controller
    {
        public ProductosDatos _ProductosDatos;
        public ProductosDatosDTO _ProductosDatosDTOProv;
        public ProductosDatosDTO _ProductosDatosDTOCat;

        public ProductosController(IConfiguration _configuration) 
        {
            _ProductosDatos = new ProductosDatos(_configuration);    
            _ProductosDatosDTOProv = new ProductosDatosDTO(_configuration); 
            _ProductosDatosDTOCat  = new ProductosDatosDTO(_configuration);
        }

        public IActionResult Listar()
        {
            var oLista = _ProductosDatos.Listar();
            return View(oLista);
        }

        public IActionResult Crear()
        {
            var LProveedores = _ProductosDatosDTOProv.ListarProveedores();
            var LCategorias = _ProductosDatosDTOCat.ListarCategorias();

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


            var LProveedores = _ProductosDatosDTOProv.ListarProveedores();
            var LCategorias = _ProductosDatosDTOCat.ListarCategorias();

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


    }
}
