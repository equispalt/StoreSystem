using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
	public class IngresosController : Controller
	{
		public IngresosDatos _IngresosDatos;
		public DatosDTO _DatosDTOProd;
		public IngresosController(IConfiguration _configuration)
		{
			_IngresosDatos = new IngresosDatos(_configuration);
			_DatosDTOProd = new DatosDTO(_configuration);	
		}

		public IActionResult Crear()
		{
            var LProductos = _DatosDTOProd.ListarProductos();

			ViewBag.oProductos = LProductos;

            return View();
		}

		[HttpPost]
		public IActionResult Crear(Ingresos oIngresos) 
		{

            var respuesta = _IngresosDatos.Crear(oIngresos);

			if (respuesta)
			{
				return RedirectToAction("MostrarExistencias","Existencias");
			}
			else
			{
				return View();
			}
		}

		public IActionResult Listar() 
		{
			var oLista = _IngresosDatos.Listar();
			return View(oLista);	
		}

	}
}
