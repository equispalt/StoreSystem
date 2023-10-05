
using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class DatosDTO
    {
        private readonly IConfiguration _configuration;

        public DatosDTO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Productos> ListarProductos()
        {
            var oLista = new List<Productos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("ListarProductos", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new Productos()
                            {
                                id_producto = dr.GetInt32("id_producto"),
                                nombre_producto = dr["ProductosFull"].ToString()
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
        public List<Productos> ListarProveedores()
        { 
        var oLista = new List<Productos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                { 
                    connectionString.Open(); 
                    SqlCommand cmd = new SqlCommand("ListarProveedores", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new Productos()
                            {
                                id_proveedor = dr.GetInt32("id_proveedor"),
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

        public List<Productos> ListarCategorias()
        {
            var oLista = new List<Productos>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("ListarCategorias", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new Productos()
                            {
                                id_categoria = dr.GetInt32("id_categoria"),
                                nombre_categoria = dr["nombre_categoria"].ToString()
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
