using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class FacturasDatosDTO
    {
        private readonly IConfiguration _configuration;

        public FacturasDatosDTO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<FacEncabezado> ListarFactura()
        {
            var oLista = new List<FacEncabezado>();

            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("[SP_FacturaListar]", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new FacEncabezado()
                            {
                                id_factura = dr.GetInt32("id_factura"),
                                nit_cliente = dr["nit_cliente"].ToString(),
                                forma_pago = dr["forma_pago"].ToString(),
                                nombre_moneda = dr["nombre_moneda"].ToString(),
                                total_factura = dr.GetFloat("total_factura"),
                                fecha_factura = dr.GetDateTime("fecha_factura"),
                                estado_factura = dr["estado_factura"].ToString()
                            });
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return oLista;
        }
        public List<FacturasDTO> CorrelativoFactura()
        {
            var oLista = new List<FacturasDTO>();

            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("[FacturaIDSiguiente]", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new FacturasDTO()
                            {
                                id_factura = dr.GetInt32("id_factura")
                            });
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return oLista;
        }

        public List<Clientes> ClientesFactura(string nit = null)
        {
            var oLista = new List<Clientes>();

            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CliListar", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (!string.IsNullOrEmpty(nit))
                    {
                        // Si se proporciona un NIT, configurar el parámetro de búsqueda
                        cmd.Parameters.Add(new SqlParameter("@nitCliente", nit));
                    }

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Clientes()
                            {

                                id_cliente = dr.GetInt32("id_cliente"),
                                nombre_cliente = dr["nombre_cliente"].ToString(),
                                apellido_cliente = dr["apellido_cliente"].ToString(),
                                dpi_cliente = dr["dpi_cliente"].ToString(),
                                nit_cliente = dr["nit_cliente"].ToString(),
                                telefono_cliente = dr["telefono_cliente"].ToString(),
                                direccion_cliente = dr["direccion_cliente"].ToString(),
                                correo_cliente = dr["correo_cliente"].ToString()

                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return oLista;
        }

        public List<Productos> ProductosFactura()
        {
            var oLista = new List<Productos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("[SP_FacturaProducto]", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new Productos()
                            {
                                id_producto = dr.GetInt32("id_producto"),
                                nombre_producto = dr["nombre_producto"].ToString(),
                                marca_producto = dr["marca_producto"].ToString(),
                                descripcion_producto = dr["descripcion_producto"].ToString(),
                                estatus_producto = dr["estatus_producto"].ToString(),
                                precio_unidad = dr.GetFloat("precio_unidad")
                            });
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return oLista;
        }
    }
}
