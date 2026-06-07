using AppPeliculas.Application.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppPeliculas.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly GetMoviesUseCase _getMoviesUseCase;

        public MovieController(GetMoviesUseCase getMoviesUseCase)
        {
            _getMoviesUseCase = getMoviesUseCase;
        }

        [HttpGet]  
        public IActionResult GetAll()
        {
            try
            {
                var movies = _getMoviesUseCase.GetMovies();  
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
