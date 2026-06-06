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
    public class MovieRepository : IMovieIRepository
    {
        public AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        public Movie? GetById(Guid id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }

        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }
    }
}
