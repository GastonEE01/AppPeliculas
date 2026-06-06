using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public  class AddFavoriteMovieUseCase
    {
        public readonly IFavoriteMovieRepository _favoriteMovieRepository;
        
        public AddFavoriteMovieUseCase(IFavoriteMovieRepository favoriteMovieRepository)
        {
            _favoriteMovieRepository = favoriteMovieRepository;
        }

        public FavoriteMovie AddFavorite(Guid userId, Guid movieId)
        {
            if (userId == Guid.Empty || movieId == Guid.Empty)
                throw new ArgumentException("No se encontro el usuario o la pelicula");

            var yaEsFavorito = _favoriteMovieRepository.Exists(userId, movieId);
            if (yaEsFavorito)
            {
                throw new Exception("Esta película ya se encuentra en tus favoritos.");
            }

            var favoriteMovie = new FavoriteMovie {
                MovieId = movieId,
                UserId = userId
            };

            _favoriteMovieRepository.add(favoriteMovie);

            return favoriteMovie;
        }
        
    }
}
