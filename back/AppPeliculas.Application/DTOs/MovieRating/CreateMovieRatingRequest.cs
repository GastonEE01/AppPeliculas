using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.DTOs.MovieRating
{
    public class CreateMovieRatingRequest
    {
        public Guid MovieId { get; set; }
        public int Stars { get; set; }

    }
}
