using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;

namespace StoreSystem.Datos
{
    public class ReporteDatos
    {

        private readonly IConfiguration _configuration;

        public ReporteDatos(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Reportes> Listar()
        {
            var oLista = new List<Reportes>();

            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    connectionString.Open();
                    SqlCommand cmd = new SqlCommand("Sp_reportedia", connectionString);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Reportes()
                            {

                                nombre_categoria = dr["nombre_categoria"].ToString(),
                                subtotal_detalle = dr.GetFloat("nombre_cliente"),
                                cantidad_detalle = dr.GetFloat("cantidad_detalle")
                                

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

    }
}
