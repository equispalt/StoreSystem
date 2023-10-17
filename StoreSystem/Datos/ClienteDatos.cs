using StoreSystem.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StoreSystem.Datos
{
    public class ClienteDatos
    {
        private readonly IConfiguration _configuration;

        public ClienteDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Clientes> Listar(string nit=null)
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

        public Clientes Buscar(int idCliente)
        {
            var oCliente = new Clientes();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CliBuscarID", connectionString);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);


                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCliente.id_cliente = dr.GetInt32("id_cliente");
                            oCliente.nombre_cliente = dr["nombre_cliente"].ToString();
                            oCliente.apellido_cliente = dr["apellido_cliente"].ToString();
                            oCliente.dpi_cliente = dr["dpi_cliente"].ToString();
                            oCliente.nit_cliente = dr["nit_cliente"].ToString();
                            oCliente.telefono_cliente = dr["telefono_cliente"].ToString();
                            oCliente.direccion_cliente = dr["direccion_cliente"].ToString();
                            oCliente.correo_cliente = dr["correo_cliente"].ToString();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return oCliente;
        }

        public bool Crear(Clientes oCliente)
        {
            bool rpta;
            try
            {
                using (var connectioString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectioString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CliCrear", connectioString);

                    cmd.Parameters.AddWithValue("@nombreCliente", oCliente.nombre_cliente);
                    cmd.Parameters.AddWithValue("@apellidoCliente", oCliente.apellido_cliente);
                    cmd.Parameters.AddWithValue("@dpiCliente", oCliente.dpi_cliente);
                    cmd.Parameters.AddWithValue("@nitCliente", oCliente.nit_cliente);
                    cmd.Parameters.AddWithValue("@telefonoCliente", oCliente.telefono_cliente);
                    cmd.Parameters.AddWithValue("@direccionCliente", oCliente.direccion_cliente);
                    cmd.Parameters.AddWithValue("@correoCliente", oCliente.correo_cliente);
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

        public bool Editar(Clientes oCliente)
        {
            bool rpta;
            try
            {
                using (var connectioString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectioString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CliActualizar", connectioString);
                    cmd.Parameters.AddWithValue("@idCliente", oCliente.id_cliente);
                    cmd.Parameters.AddWithValue("@nombreCliente", oCliente.nombre_cliente);
                    cmd.Parameters.AddWithValue("@apellidoCliente", oCliente.apellido_cliente);
                    cmd.Parameters.AddWithValue("@nitCliente", oCliente.nit_cliente);
                    cmd.Parameters.AddWithValue("@dpiCliente", oCliente.dpi_cliente);
                    cmd.Parameters.AddWithValue("@telefonoCliente", oCliente.telefono_cliente);
                    cmd.Parameters.AddWithValue("@direccionCliente", oCliente.direccion_cliente);
                    cmd.Parameters.AddWithValue("@correoCliente", oCliente.correo_cliente);

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

        public bool Eliminar(Clientes oCliente)
        {
            bool rpta;
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CliEliminar", connectionString);
                    cmd.Parameters.AddWithValue("@idCliente", oCliente.id_cliente);
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


    } //finaliza clase
} // finaliza namespace
