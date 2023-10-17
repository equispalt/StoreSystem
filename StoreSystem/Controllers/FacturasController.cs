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

            var oFacProducto = _FacturaDatosDTO.ProductosFactura();
            ViewBag.FacProducto = oFacProducto;

            return View();
        }

    }
}
