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


    }
}
