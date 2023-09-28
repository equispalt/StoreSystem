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

        public Productos Buscar(int idProducto)
        {
            var oProducto = new Productos();

            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProdBuscarID", connectionString);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oProducto.id_producto = dr.GetInt32("id_producto");
                            oProducto.nombre_producto = dr["nombre_producto"].ToString();
                            oProducto.marca_producto = dr["marca_producto"].ToString();
                            oProducto.descripcion_producto = dr["descripcion_producto"].ToString();
                            oProducto.estatus_producto = dr["estatus_producto"].ToString();
                            oProducto.nombre_categoria = dr["nombre_categoria"].ToString();
                            oProducto.nombre_proveedor = dr["nombre_proveedor"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            return oProducto;
        }

        public bool Crear(Productos oProducto)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProdCrear", connectionString);

                    cmd.Parameters.AddWithValue("@nombreProducto", oProducto.nombre_producto);
                    cmd.Parameters.AddWithValue("@marcaProducto", oProducto.marca_producto);
                    cmd.Parameters.AddWithValue("@descripcionProducto", oProducto.descripcion_producto);
                    cmd.Parameters.AddWithValue("@estatusProducto", oProducto.estatus_producto);
                    cmd.Parameters.AddWithValue("@categoriaId", oProducto.categoria_id);
                    cmd.Parameters.AddWithValue("@proveedorId", oProducto.proveedor_id);
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

        public bool Editar(Productos oProducto)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProdActualizar", connectionString);
                    cmd.Parameters.AddWithValue("@idProducto", oProducto.id_producto);
                    cmd.Parameters.AddWithValue("@nombreProducto", oProducto.nombre_producto);
                    cmd.Parameters.AddWithValue("@marcaProducto", oProducto.marca_producto);
                    cmd.Parameters.AddWithValue("@descripcionProducto", oProducto.descripcion_producto);
                    cmd.Parameters.AddWithValue("@estatusProducto", oProducto.estatus_producto);
                    cmd.Parameters.AddWithValue("@categoriaId", oProducto.categoria_id);
                    cmd.Parameters.AddWithValue("@proveedorId", oProducto.proveedor_id);
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

        public bool Eliminar(Proveedores oProveedor)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProdEliminar", connectionString);
                    cmd.Parameters.AddWithValue("@idProveedor", oProveedor.id_proveedor);
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
