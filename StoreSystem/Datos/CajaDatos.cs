using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;
using System.Security.Claims;

namespace StoreSystem.Datos
{
    public class CajaDatos
    {
        private readonly IConfiguration _configuration;

        public CajaDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool VerificarCajaAbierta(int IdUsr)
        {

            bool cajaAbierta = false;
            try
            {
                using (SqlConnection connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    SqlCommand cmd = new SqlCommand("[VerificarCajaAbierta]", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsr", IdUsr);
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    
                    connectionString.Open();

                    cmd.ExecuteNonQuery();

                    cajaAbierta = Convert.ToBoolean(cmd.Parameters["@estado"].Value);
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return cajaAbierta;
        }

        public List<Caja> Estados()
        {
            var oLista = new List<Caja>();
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("SP_CajaEstados", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Caja caja = new Caja();
                            caja.id_caja = dr.GetInt32(dr.GetOrdinal("id_caja"));
                            caja.MontoInicial = dr.GetFloat(dr.GetOrdinal("MontoInicial"));
                            caja.fecha_apertura = dr.GetDateTime(dr.GetOrdinal("fecha_apertura"));

                            // Verificar si fecha_cierre es DBNull
                            if (!dr.IsDBNull(dr.GetOrdinal("fecha_cierre")))
                            {
                                caja.fecha_cierre = dr.GetDateTime(dr.GetOrdinal("fecha_cierre"));
                            }
                            else
                            {
                                // Puedes asignar un valor por defecto o marcarlo como nulo en tu objeto Caja.
                                caja.fecha_cierre = null;
                            }

                            caja.estado_caja = dr["estado_caja"].ToString();
                            caja.usuario_id = dr.GetInt32(dr.GetOrdinal("usuario_id"));

                            // Verificar si correoUsr es DBNull
                            if (!dr.IsDBNull(dr.GetOrdinal("correoUsr")))
                            {
                                caja.correoUsr = dr["correoUsr"].ToString();
                            }
                            else
                            {
                                // Puedes asignar un valor por defecto o marcarlo como nulo en tu objeto Caja.
                                caja.correoUsr = null;
                            }

                            oLista.Add(caja);
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
