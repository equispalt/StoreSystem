using Microsoft.Data.SqlClient;
using StoreSystem.Models;
using System.Data;
using System.Security.Claims;
using System.Text.Json;

namespace StoreSystem.Datos
{
	public class IngresosDatos
	{
		private readonly IConfiguration _configuration;

		public IngresosDatos(IConfiguration configuration)
		{
			_configuration = configuration;
		}	

		public bool Crear(Ingresos oIngresos)
		{
			bool rpta;
			
			try
			{
				using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
				{
					connectionString.Open();
					SqlCommand cmd = new SqlCommand("SP_IngreCrear", connectionString);

					cmd.Parameters.AddWithValue("@productoId", oIngresos.producto_id);
					cmd.Parameters.AddWithValue("@cantidadIngreso", oIngresos.cantidad_ingreso);
					cmd.Parameters.AddWithValue("@costoIngreso", oIngresos.costo_ingreso);
					cmd.Parameters.AddWithValue("@fechaVencimiento", oIngresos.fecha_vencimiento);
					cmd.Parameters.AddWithValue("@usuarioId", oIngresos.usuario_id);
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
