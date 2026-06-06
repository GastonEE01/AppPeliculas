using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class GetFavoriteMovieUserUseCase
    {
        private readonly IFavoriteMovieRepository _favoriteMovie;

        public GetFavoriteMovieUserUseCase(IFavoriteMovieRepository favoriteMovie)
        {
            _favoriteMovie = favoriteMovie;
        }

      
        public async Task<List<Movie>> GetFavoriteMovie(Guid idUser)
        {
            if (idUser == Guid.Empty)
                throw new ArgumentException("Usuario no encontrado");

            return _favoriteMovie.GetFavoritesByUserId(idUser);
        }

    }
}
