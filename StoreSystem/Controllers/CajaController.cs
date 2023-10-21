using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;
using System.Security.Claims;

namespace StoreSystem.Controllers
{
    public class CajaController : Controller
    {
        public CajaDatos _CajaDatos;

        public CajaController(IConfiguration _configuration)
        {
            _CajaDatos = new CajaDatos(_configuration);
        }
        public IActionResult estados()
        {
            var oLista = _CajaDatos.Estados();
            return View(oLista);
        }
        public IActionResult Crear()
        {
            // Metodo que solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Caja oCaja)
        {

            // Metodo que recibe el objeto para guardarlo en DB
            var respuesta = _CajaDatos.Crear(oCaja);

            if (respuesta)
            {
                return RedirectToAction("Estados");
            }
            else
                return View();
        }

        public IActionResult Editar(int idcaja)
        {
            var ocaja = _CajaDatos.Buscar(idcaja);

            // Metodo que solo devuelve la vista
            return View(ocaja);
        }

        [HttpPost]
        public IActionResult Editar(Caja oCaja)
        {

            // Metodo que recibe el objeto para guardarlo en DB
            var respuesta = _CajaDatos.Editar(oCaja);

            if (respuesta)
            {
                return RedirectToAction("estados");
            }
            else
                return View();
        }


    }
}
