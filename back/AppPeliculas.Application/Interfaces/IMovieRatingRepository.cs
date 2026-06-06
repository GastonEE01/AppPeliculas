using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.Interfaces
{
    public interface IMovieRatingRepository
    {
        MovieRating add(MovieRating movieRating);
    }
}
