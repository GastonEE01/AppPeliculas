using AppPeliculas.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppPeliculas.API.Controllers
{
    [Route("api/[controller]")]
    public class TestDbController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Le pedimos a .NET que nos pase el mapa de la base de datos (AppDbContext)
        public TestDbController(AppDbContext _context)
        {
            this._context = _context;
        }

        [HttpGet("check-connection")]
        public IActionResult CheckConnection()
        {
            try
            {
                // .Database.CanConnect() intenta abrir y cerrar una conexion real con Supabase
                bool puedoConectarme = _context.Database.CanConnect();

                if (puedoConectarme)
                {
                    return Ok(new { estado = "Éxito", mensaje = "¡El Backend se conectó correctamente a Supabase!" });
                }
                else
                {
                    return StatusCode(500, new { estado = "Error", mensaje = "No se pudo establecer conexión con Supabase." });
                }
            }
            catch (Exception ex)
            {
                // Si la contraseña o el usuario están mal, va a saltar acá y te va a decir el porqué
                return StatusCode(500, new { estado = "Error crítico", detalle = ex.Message });
            }
        }
    
}
}
