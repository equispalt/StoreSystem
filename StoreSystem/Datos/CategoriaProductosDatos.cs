using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class CategoriaProductosDatos
    {
        private readonly IConfiguration _configuration;
        public CategoriaProductosDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CategoriaProductos> Listar() 
        {
            var oLista = new List<CategoriaProductos>();
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

        public CategoriaProductos Buscar(int idCategoria) 
        {
            var oCategoria = new CategoriaProductos();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CatBuscarID", connectionString);
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);

                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCategoria.id_categoria = dr.GetInt32("id_categoria");
                            oCategoria.nombre_categoria = dr["nombre_categoria"].ToString();
                            oCategoria.descripcion_categoria = dr["descripcion_categoria"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        return oCategoria;  
        }

        public bool Crear(CategoriaProductos oCategoriaProductos)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CatCrear", connectionString);

                    cmd.Parameters.AddWithValue("@nombreCategoria", oCategoriaProductos.nombre_categoria);
                    cmd.Parameters.AddWithValue("@descripcionCategoria", oCategoriaProductos.descripcion_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Editar(CategoriaProductos oCategoriaProductos)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CatActualizar", connectionString);
                    cmd.Parameters.AddWithValue("@idCategoria", oCategoriaProductos.id_categoria);
                    cmd.Parameters.AddWithValue("@nombreCategoria", oCategoriaProductos.nombre_categoria);
                    cmd.Parameters.AddWithValue("@descripcionCategoria", oCategoriaProductos.descripcion_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(CategoriaProductos oCategoriaProductos)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CatEliminar", connectionString);
                    cmd.Parameters.AddWithValue("@idCategoria", oCategoriaProductos.id_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
