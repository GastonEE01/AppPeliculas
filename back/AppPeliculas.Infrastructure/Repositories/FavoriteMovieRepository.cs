using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using AppPeliculas.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Infrastructure.Repositories
{
    public class FavoriteMovieRepository : IFavoriteMovieRepository
    {
        public AppDbContext _context;

        public FavoriteMovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public FavoriteMovie add(FavoriteMovie favoriteMovie)
        {
            _context.FavoriteMovies.Add(favoriteMovie);
            _context.SaveChanges();
            return favoriteMovie;
        }

        public bool delete(Guid idMovie, Guid idUser)
        {
            var favorite = _context.FavoriteMovies
                .FirstOrDefault(f => f.UserId == idUser && f.MovieId == idMovie);
          if(favorite == null) 
                return false;
          
          _context.FavoriteMovies.Remove(favorite);
            Console.WriteLine($"UserId: {idUser}");
            Console.WriteLine($"MovieId: {idMovie}");
            _context.SaveChanges();
            return true;
        }

        public bool Exists(Guid userId, Guid movieId)
        {
            bool exist = _context.FavoriteMovies
                .Any(x => x.UserId ==  userId && x.MovieId == movieId);

            return exist;

        }

        public Task<List<FavoriteMovie>> GetFavoriteMovieById(Guid idUser)
        {
            throw new NotImplementedException();
        }

        public List<Movie> GetFavoritesByUserId(Guid userId)
        {
            return _context.FavoriteMovies
                   .Where(f => f.UserId == userId)
                   .Select(f => f.Movie)
                   .ToList();
        }

       
    }
}
