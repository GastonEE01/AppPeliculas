using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class UserAddMovieRatingUseCase 
    {
        public readonly IMovieRatingRepository _movieRating;
        public readonly IUserRepository _userRepository;
        public readonly IMovieIRepository _movieRepository;


        public UserAddMovieRatingUseCase(IMovieRatingRepository movieRating,IUserRepository userRepository, IMovieIRepository movieRepository)
        {
            _movieRating = movieRating;
            _userRepository = userRepository;
            _movieRepository = movieRepository;
        }

        public MovieRating UserAddMovieRating(Guid idUser,Guid idMovie, int stars)
        {
            if (stars < 1 || stars > 5)
                throw new Exception("La valoración debe estar entre 1 y 5");

            User user = _userRepository.GetById(idUser);
            Movie movie = _movieRepository.GetById(idMovie);

            if (user == null) 
                throw new ArgumentNullException("No se encontro al usuario");

            if (movie == null)
                throw new ArgumentNullException("No se encontro la pelicula");

            var movieRating = new MovieRating
            {
                MovieId = idMovie,
                UserId = idUser,
                Start = stars,
            };

           return _movieRating.add(movieRating);

        }
    }
}
