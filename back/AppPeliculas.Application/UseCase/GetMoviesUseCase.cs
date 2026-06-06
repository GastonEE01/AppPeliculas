using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class GetMoviesUseCase
    {
        public readonly IMovieIRepository _movieRepository;

        public GetMoviesUseCase (IMovieIRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie GetMovies(Guid idMovie)
        {
            if (idMovie == Guid.Empty)
            {
                throw new ArgumentException("El ID de la película no es válido.");
            }
            
            var movie = _movieRepository.GetById(idMovie);

            // Si el repositorio devuelve null, lanzamos excepción o manejamos el error
            if (movie == null)
            {
                throw new Exception($"No se encontró la película con el ID {idMovie}");
            }

            return movie;
        }

        public List<Movie> GetMovies()
        {
            List <Movie> movies = _movieRepository.GetMovies(); 
            return movies;

        }
    }
}
