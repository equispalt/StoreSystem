using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class ProductosDatos
    {
        private readonly IConfiguration _configuration;
        public ProductosDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Productos> Listar()
        {
            var oLista = new List<Productos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("[SP_ProdListar]", connectionString);
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
                                nombre_categoria = dr["nombre_categoria"].ToString(),
                                nombre_proveedor = dr["nombre_proveedor"].ToString()
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
