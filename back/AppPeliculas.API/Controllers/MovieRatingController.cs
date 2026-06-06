using AppPeliculas.Application.DTOs.MovieRating;
using AppPeliculas.Application.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppPeliculas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieRatingController : ControllerBase
    {
        private readonly UserAddMovieRatingUseCase _movieRating;

        public MovieRatingController(UserAddMovieRatingUseCase movieRating)
        {
            _movieRating = movieRating;
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateRating([FromBody] CreateMovieRatingRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Console.WriteLine(userIdClaim);
                if (!Guid.TryParse(userIdClaim, out Guid userId))
                    return Unauthorized();

                _movieRating.UserAddMovieRating(
                    userId,
                    request.MovieId,     
                    request.Stars
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });

            }
        }
    }
}


        
