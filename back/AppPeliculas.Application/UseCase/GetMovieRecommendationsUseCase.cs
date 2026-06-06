using AppPeliculas.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class GetMovieRecommendationsUseCase
    {
        private readonly IFavoriteMovieRepository _favoriteRepo;
        private readonly IAIService _aiService;

        public GetMovieRecommendationsUseCase(IFavoriteMovieRepository favoriteRepo,IAIService aiService)
        {
            _favoriteRepo = favoriteRepo;
            _aiService = aiService;
        }

        public async Task<string> Execute(Guid userId)
        {
            var favorites = _favoriteRepo.GetFavoritesByUserId(userId);

            var favoriteTitles = favorites.Select(f => f.Title);

            var prompt = $@"
Sos un recomendador de películas.

El usuario tiene estas películas favoritas:
{string.Join(", ", favoriteTitles)}

Recomendá 5 películas similares.
Solo devolvé los nombres.
";

            return await _aiService.GetRecommendations(prompt);
        }
    }
}
