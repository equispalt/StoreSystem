using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

using StoreSystem.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Configuration;
namespace StoreSystem.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IConfiguration _configuration;
        public AccesoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //Get: Acceso
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Usuarios oUsuarios)
        {
            oUsuarios.passwordUsr = ConvertirSHA256(oUsuarios.passwordUsr);
            try
            {
                using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
                {
                    var cmd = new SqlCommand("sp_ValidarUsuario", connectionString);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Correo", System.Data.SqlDbType.VarChar).Value = oUsuarios.correoUsr;
                    cmd.Parameters.AddWithValue("@Clave", System.Data.SqlDbType.VarChar).Value = oUsuarios.passwordUsr;

                    connectionString.Open();

                    oUsuarios.idUsr = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (System.Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }

            if (oUsuarios.idUsr != 0)
            {
                await SetSession(oUsuarios);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "usuario no encontrado";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Registrar(Usuarios oUsuarios)
        {
            bool registrado;
            string mensaje;

            if (oUsuarios.passwordUsr == oUsuarios.ConfirmarClave)
            {
                oUsuarios.passwordUsr = ConvertirSHA256(oUsuarios.passwordUsr);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (var connectionString = new SqlConnection(_configuration.GetConnectionString("conexion")))
            {
                var cmd = new SqlCommand("sp_RegistrarUsuario", connectionString);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@correo", oUsuarios.correoUsr);
                cmd.Parameters.AddWithValue("@clave", oUsuarios.passwordUsr);
                cmd.Parameters.AddWithValue("@nombre", oUsuarios.nombreUsr);
                cmd.Parameters.AddWithValue("@apellido", oUsuarios.apellidoUsr);
                cmd.Parameters.Add("@registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                connectionString.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["@registrado"].Value);
                mensaje = cmd.Parameters["@mensaje"].Value.ToString();

            }

            ViewData["@mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "Acceso");
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Acceso");
        }

        public static string ConvertirSHA256(string texto)
        {
            // referencia de "System.security.cryptography"
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        private async Task SetSession(Usuarios usuario)
        {
            List<Claim> sesion = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, usuario.correoUsr),
                new Claim(ClaimTypes.NameIdentifier , usuario.idUsr.ToString())
            };

            ClaimsIdentity identidad = new(sesion, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties autenticacionPropiedad = new();

            autenticacionPropiedad.AllowRefresh = true;
            autenticacionPropiedad.IsPersistent = true;
            autenticacionPropiedad.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identidad), autenticacionPropiedad);
        }
    }
}
