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

        public List<CategoriaProductos> Listar()
        {
            var oLista = new List<Productos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CatListar", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new CategoriaProductos()
                            {
                                id_categoria = dr.GetInt32("id_categoria"),
                                nombre_categoria = dr["nombre_categoria"].ToString(),
                                descripcion_categoria = dr["descripcion_categoria"].ToString()
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
