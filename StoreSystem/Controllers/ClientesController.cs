using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;
using StoreSystem.Models;
using System.Configuration;

namespace StoreSystem.Controllers
{
    public class ClientesController : Controller
    {
        private ClienteDatos _ClienteDatos;  // Declarar una instancia de ClienteDatos

        public ClientesController(IConfiguration _configuration)
        {
            _ClienteDatos = new ClienteDatos(_configuration); // Inicializar la instancia en el constructor

        }

        //Get: Listar
        public IActionResult Listar(string nit = null)
        {
            List<Clientes> oLista;

            if (!string.IsNullOrEmpty(nit))
            {
                oLista = _ClienteDatos.Listar(nit);
            }
            else
            {
                // La vista Mostrara una lista de clientes	
                oLista = _ClienteDatos.Listar();
            }
            return View(oLista); // Devolver una vista con los datos obtenidos
        }

        public IActionResult Crear()
        {
            // Metodo que solo devuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Clientes oCliente)
        {

            if (!ModelState.IsValid)
                return View();

            // Metodo que recibe el objeto para guardarlo en DB
            var respuesta = _ClienteDatos.Crear(oCliente);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }

        public IActionResult Editar(int idCliente)
        {
            var ocliente = _ClienteDatos.Buscar(idCliente);

            // Metodo que solo devuelve la vista
            return View(ocliente);
        }

        [HttpPost]
        public IActionResult Editar(Clientes oCliente)
        {

            if (!ModelState.IsValid)
                return View();

            // Metodo que recibe el objeto para guardarlo en DB
            var respuesta = _ClienteDatos.Editar(oCliente);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
                return View();
        }

        public IActionResult Eliminar(int idCliente)
        {
            var ocliente = _ClienteDatos.Buscar(idCliente);

            return View(ocliente);
        }

        [HttpPost]
        public IActionResult Eliminar(Clientes oCliente)
        {

            var respuesta = _ClienteDatos.Eliminar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();

        }



    }// fin class ClienteController
}// f