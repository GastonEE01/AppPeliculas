using AppPeliculas.Application.DTOs.FavoriteMovie;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppPeliculas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteMovieController : ControllerBase
    {
        public readonly AddFavoriteMovieUseCase _addFavoriteMovieUseCase;
        public readonly GetFavoriteMovieUserUseCase _getFavoriteMovieUserUseCase;
        public readonly DeleteFavoriteMovieUserUseCase _deleteFavoriteMovieUserUseCase;

        public FavoriteMovieController(AddFavoriteMovieUseCase addFavoriteMovieUseCase, GetFavoriteMovieUserUseCase getFavoriteMovieUserUseCase, DeleteFavoriteMovieUserUseCase deleteFavoriteMovieUserUseCase)
        {
            _addFavoriteMovieUseCase = addFavoriteMovieUseCase;
            _getFavoriteMovieUserUseCase = getFavoriteMovieUserUseCase;
            _deleteFavoriteMovieUserUseCase = deleteFavoriteMovieUserUseCase;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMoviesUser(Guid userId)
        {
            try
            {
                var favorites = await _getFavoriteMovieUserUseCase.GetFavoriteMovie(userId);

                var response = favorites.Select(m => new FavoriteMovieUserResponseDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Category = m.Category,
                    Img = m.IMG,
                    Qualification = m.Qualification
                }).ToList();

                return Ok(response);

            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult AddFavorite([FromBody] AddFavoriteDtoRequest dto)
        {
            try
            {
                FavoriteMovie favorite = _addFavoriteMovieUseCase.AddFavorite(dto.UserId, dto.MovieId);

                var response = new FavoriteMovieResponseDto
                {
                    Id = favorite.Id,
                    UserId = favorite.UserId,
                    MovieId = favorite.MovieId
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{IdMovie}")]
        public IActionResult DeleteFavorite(Guid IdMovie)
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (!Guid.TryParse(userIdClaim, out Guid userId))
                    return Unauthorized();

                _deleteFavoriteMovieUserUseCase.DeleteFavoriteMovie(IdMovie, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
