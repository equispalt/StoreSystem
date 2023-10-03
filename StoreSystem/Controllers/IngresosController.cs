using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;

namespace StoreSystem.Controllers
{
	public class IngresosController : Controller
	{
		public IngresosDatos _IngresosDatos;

		public IngresosController(IConfiguration _configuration)
		{
			_IngresosDatos = new IngresosDatos(_configuration);
		}

		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Crear(Ingresos oIngresos) 
		{
            if (!ModelState.IsValid)
            {
                return View();
            }

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
	}
}
