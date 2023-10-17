using MessagePack;
using Microsoft.AspNetCore.Mvc;
using StoreSystem.Datos;

namespace StoreSystem.Controllers
{
    public class FacturasController : Controller
    {
        public FacturasDatosDTO _FacturaDatosDTO;

        public FacturasController(IConfiguration configuration)
        { 
            _FacturaDatosDTO = new FacturasDatosDTO(configuration);
        }

        public IActionResult CrearFactura()
        {
            var oFacID = _FacturaDatosDTO.CorrelativoFactura();
            ViewBag.FacID = oFacID;

            var oFacCliente = _FacturaDatosDTO.ClientesFactura();
            ViewBag.FacCliente = oFacCliente;

            return View();
        }

        public IActionResult BuscarPorNit(string nit)
        {
            // Realiza la búsqueda en tu capa de datos y obtén los resultados
            var FaCliente = _FacturaDatosDTO.ClientesFactura(nit);

            // Devuelve una vista parcial o una vista con los datos del cliente encontrado
            return PartialView("_ResultadoBusquedaCliente", FaCliente);
        }
    }
}
