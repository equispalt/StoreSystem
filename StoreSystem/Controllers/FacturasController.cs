using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using StoreSystem.Datos;
using StoreSystem.Models;
using System.Data;
using System.Security.Claims;
using System.Xml.Linq;

namespace StoreSystem.Controllers
{
    [Authorize]
    public class FacturasController : Controller
    {
        public FacturasDatosDTO _FacturaDatosDTO;
        public CajaDatos _CajaDatos;


        private readonly IConfiguration _cadenasql;
        public FacturasController(IConfiguration _configuration)
        { 
            _FacturaDatosDTO = new FacturasDatosDTO(_configuration);
            _CajaDatos = new CajaDatos(_configuration);
            _cadenasql = _configuration;

        }

        public IActionResult ListarFactura()
        {
            var oLista = _FacturaDatosDTO.ListarFactura();

            return View(oLista);
        }

        public JsonResult VerificarCorte(string userID)
        {
            int usrID = Convert.ToInt32(userID);
            bool corteAbierto = _CajaDatos.VerificarCajaAbierta(usrID); // Reemplaza con tu lógica real

            return Json(new { corteAbierto });
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

        [HttpPost]
        public JsonResult GuardarFactura([FromBody] FacEncabezado body)
        {
            XElement factura = new XElement("FacEncabezado",
                //id_factura ES AUTOMATICO
                // fecha_factura se genera desde el SP
                new XElement("cliente_id", body.cliente_id),
                new XElement("id_pago", body.id_pago),
                new XElement("id_moneda", body.id_moneda),

                // ESTADO SE GENERA DESDE EL SP
                new XElement("total_factura", body.total_factura)
            );

            XElement oDetalleFactura = new XElement("FacDetalle");
            foreach (FacDetalle item in body.lstFacDetalle)
            {
                oDetalleFactura.Add(new XElement("Item",
                    new XElement("producto_id", item.producto_id),
                    new XElement("cantidad_detalle", item.cantidad_detalle),
                    new XElement("precio_detalle", item.precio_detalle),
                    new XElement("subtotal_detalle", item.subtotal_detalle)
                    ));
            }
            factura.Add(oDetalleFactura);

            using (SqlConnection oconexion = new SqlConnection(_cadenasql.GetConnectionString("conexion")))
            {
                oconexion.Open();
                SqlCommand cmd = new SqlCommand("[SP_FacturaGuardar]", oconexion);
                cmd.Parameters.Add("@fac_xml", SqlDbType.Xml).Value = factura.ToString();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }

            return Json(new { respuesta = true });
        }

        public IActionResult VerFactura(int idfactura)
        {
            var oFacEnc = _FacturaDatosDTO.BuscarFacturaEnc(idfactura);
            var oFacDet = _FacturaDatosDTO.BuscarFacturaDet(idfactura);

            ViewBag.VoFacEnc = oFacEnc;
            ViewBag.VoFacDet = oFacDet;


            // Metodo que solo devuelve la vista
            return View();
        }

        public IActionResult AnularFactura(int idfactura)
        {
            var ofactura = _FacturaDatosDTO.BuscarFacturaEnc(idfactura);

            // Metodo que solo devuelve la vista
            return View(ofactura);
        }

        [HttpPost]
        public IActionResult AnularFactura(FacturasDTO oFactura)
        {

            // Metodo que recibe el objeto para guardarlo en DB
            var respuesta = _FacturaDatosDTO.AnularFactura(oFactura);

            if (respuesta)
            {
                return RedirectToAction("ListarFactura");
            }
            else
                return View();
        }

    }
}
