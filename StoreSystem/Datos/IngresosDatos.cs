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

					cmd.Parameters.AddWithValue("@compraId", oIngresos.compra_id);
					cmd.Parameters.AddWithValue("@productoId", oIngresos.producto_id);
					cmd.Parameters.AddWithValue("@cantidadIngreso", oIngresos.cantidad_ingreso);
					cmd.Parameters.AddWithValue("@costoIngreso", oIngresos.costo_ingreso);
					cmd.Parameters.AddWithValue("@fechaVencimiento", oIngresos.fecha_vencimiento);
					cmd.Parameters.AddWithValue("@comentarioIngreso", oIngresos.comentario_ingreso);
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

		public List<Ingresos> Listar() 
		{ 
			var oLista = new List<Ingresos>();
			try
			{
				using (var conecctionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
				{
					conecctionString.Open();
					SqlCommand cmd = new SqlCommand("[SP_IngresListar]", conecctionString);
					cmd.CommandType = CommandType.StoredProcedure;

					using (var dr = cmd.ExecuteReader())
					{
						while (dr.Read())
							oLista.Add(new Ingresos()
							{
								id_ingreso = dr.GetInt32("id_ingreso"),
								nombre_producto= dr["nombre_producto"].ToString(),
                                cantidad_ingreso = dr.GetInt32("cantidad_ingreso"),
                                costo_ingreso	= dr.GetFloat("costo_ingreso"),
                                fecha_vencimiento   = dr["fecha_vencimiento"].ToString(),
                                comentario_ingreso = dr["comentario_ingreso"].ToString(),
                                fecha_ingreso	= dr["fecha_ingreso"].ToString(),
                                correoUsr	= dr["correoUsr"].ToString(),
                            });;
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
