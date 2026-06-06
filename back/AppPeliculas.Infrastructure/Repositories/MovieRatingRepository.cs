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
    public class MovieRatingRepository : IMovieRatingRepository
    {
        private readonly AppDbContext _context;

        public MovieRatingRepository(AppDbContext context)
        {
            _context = context;
        }


        public MovieRating add(MovieRating movieRating)
        {
            _context.MovieRatings.Add(movieRating);
            _context.SaveChanges();
            return movieRating;
        }
    }
}
