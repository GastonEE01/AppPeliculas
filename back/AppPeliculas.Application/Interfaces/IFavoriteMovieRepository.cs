using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.Interfaces
{
    public interface IFavoriteMovieRepository
    {
        public FavoriteMovie add(FavoriteMovie favoriteMovie);
        public bool delete(Guid idFavoriteMovie,Guid idUser);

        bool Exists(Guid userId, Guid movieId);
        List<Movie> GetFavoritesByUserId(Guid userId);
    }
}
