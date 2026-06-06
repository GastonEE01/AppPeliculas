using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Domain.Entities
{
    public class Movie
    {
        public Guid Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string IMG { get; set; } = string.Empty;
        public double Qualification { get; set; }
        public ICollection<FavoriteMovie> FavoriteMovies { get; set; } = new List<FavoriteMovie>();
        public ICollection<MovieRating> MovieRatings { get; set; } = new List<MovieRating>();

    }

}
