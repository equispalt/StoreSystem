using Microsoft.Data.SqlClient;
using StoreSystem.Controllers;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class ExistenciasDatos
    {
        public readonly IConfiguration _configuration;

        public ExistenciasDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Existencias> Listar()
        {
            var oLista = new List<Existencias>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("[SP_ExiListar]", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new Existencias()
                            {
                                producto_id = dr.GetInt32("producto_id"),
                                nombre_producto = dr["nombre_producto"].ToString(),
                                descripcion_producto = dr["descripcion_producto"].ToString(),
                                cantidad_existencia = dr.GetInt32("cantidad_existencia"),
                                nombre_categoria = dr["nombre_categoria"].ToString(),
                                nombre_proveedor = dr["nombre_proveedor"].ToString(),
                                FechaUltimaActualizacion = dr.GetDateTime("FechaUltimaActualizacion")
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
