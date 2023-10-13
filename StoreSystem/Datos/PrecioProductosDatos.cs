using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class PrecioProductosDatos
    {
        private readonly IConfiguration _configuration;

        public PrecioProductosDatos(IConfiguration configuration)
        {
            _configuration = configuration;        
        }

        public List<PrecioProductos> Listar()
        {
            var oLista = new List<PrecioProductos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("[SP_PreListar]", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new PrecioProductos()
                            {
                                id_precio = dr.GetInt32("id_precio"),
                                producto_id = dr.GetInt32("producto_id"),
                                nombre_producto = dr["nombre_producto"].ToString(),
                                precio_unidad = dr.GetFloat("precio_unidad"),
                                fecha_vigencia = dr.GetDateTime("fecha_vigencia"),
                                fecha_configuracion = dr.GetDateTime("fecha_configuracion"),
                                correoUsr = dr["correoUsr"].ToString(),
                                estado = dr.GetInt32("estado")
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
