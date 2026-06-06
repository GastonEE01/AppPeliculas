using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class DeleteFavoriteMovieUserUseCase
    {
        private readonly IFavoriteMovieRepository _favoriteMovie;
        private readonly IUserRepository _userRepository;

        public DeleteFavoriteMovieUserUseCase(IFavoriteMovieRepository favoriteMovie , IUserRepository userRepository)
        {
            _favoriteMovie = favoriteMovie;
            _userRepository = userRepository;
        }

        public bool DeleteFavoriteMovie(Guid IdMovie, Guid idUser)
        {
            var searchUser = _userRepository.GetById(idUser);

            if (searchUser == null)
                throw new Exception("No se encontro el usuario");

            return _favoriteMovie.delete(IdMovie, idUser);
        }
   
    }
}
