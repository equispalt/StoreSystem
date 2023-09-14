
using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class ProveedorDatos
    {
        private readonly IConfiguration _configuration;

        public ProveedorDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Proveedores> Listar()
        {
            var oLista = new List<Proveedores>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProvListar", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            oLista.Add(new Proveedores()
                            {
                                id_proveedor = dr.GetInt32("id_proveedor"),
                                nombre_proveedor = dr["nombre_proveedor"].ToString(),
                                nit_proveedor = dr["nit_proveedor"].ToString(),
                                telefono_proveedor = dr["telefono_proveedor"].ToString(),
                                direccion_proveedor = dr["direccion_proveedor"].ToString(),
                                correo_proveedor = dr["correo_proveedor"].ToString()

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

        public Proveedores Buscar(int idProveedor)
        {
            var oProveedor = new Proveedores();

            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProvBuscarID", connectionString);
                    cmd.Parameters.AddWithValue("@idProveedor", idProveedor);

                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oProveedor.id_proveedor = dr.GetInt32("id_proveedor");
                            oProveedor.nombre_proveedor = dr["nombre_proveedor"].ToString();
                            oProveedor.nit_proveedor = dr["nit_proveedor"].ToString();
                            oProveedor.telefono_proveedor = dr["telefono_proveedor"].ToString();
                            oProveedor.direccion_proveedor = dr["direccion_proveedor"].ToString();
                            oProveedor.correo_proveedor = dr["correo_proveedor"].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }

            return oProveedor;
        }

        public bool Crear(Proveedores oProveedor)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProvCrear", connectionString);

                    cmd.Parameters.AddWithValue("@nombreProveedor", oProveedor.nombre_proveedor);
                    cmd.Parameters.AddWithValue("@nitProveedor", oProveedor.nit_proveedor);
                    cmd.Parameters.AddWithValue("@telefonoProveedor", oProveedor.telefono_proveedor);
                    cmd.Parameters.AddWithValue("@direccionProveedor", oProveedor.direccion_proveedor);
                    cmd.Parameters.AddWithValue("@correoProveedor", oProveedor.correo_proveedor);
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

        public bool Editar(Proveedores oProveedor)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_ProvActualizar", connectionString);
                    cmd.Parameters.AddWithValue("@idProveedor", oProveedor.id_proveedor);
                    cmd.Parameters.AddWithValue("@nombreProveedor", oProveedor.nombre_proveedor);
                    cmd.Parameters.AddWithValue("@nitProveedor", oProveedor.nit_proveedor);
                    cmd.Parameters.AddWithValue("@telefonoProveedor", oProveedor.telefono_proveedor);
                    cmd.Parameters.AddWithValue("@direccionProveedor", oProveedor.direccion_proveedor);
                    cmd.Parameters.AddWithValue("@correoProveedor", oProveedor.correo_proveedor);

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
                    SqlCommand cmd = new SqlCommand("SP_ProvEliminar", connectionString);
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
