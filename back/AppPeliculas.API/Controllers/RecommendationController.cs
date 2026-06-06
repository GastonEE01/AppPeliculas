using AppPeliculas.Application.DTOs.Recomendation;
using AppPeliculas.Application.UseCase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppPeliculas.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly GetMovieRecommendationsUseCase _useCase;
        private readonly RecomenderMoviesUserUseCase _recomenderMoviesUser;


        public RecommendationController(GetMovieRecommendationsUseCase useCase, RecomenderMoviesUserUseCase recomenderMoviesUser)
        {
            _useCase = useCase;
            _recomenderMoviesUser = recomenderMoviesUser;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized("Token inválido");
            }

            var result = await _useCase.Execute( userId);

            return Ok(new { recommendations = result });
        }

        [HttpPost]
        public async Task<IActionResult> Recomendation([FromBody] RecomendationRequestDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userIdClaim, out Guid userId))
            {
                return Unauthorized("Token inválido");
            }

            var result = await _recomenderMoviesUser.ResponseAI(userId, dto.Message);

            return Ok(new { recommendations = result });
        }
    }
}
