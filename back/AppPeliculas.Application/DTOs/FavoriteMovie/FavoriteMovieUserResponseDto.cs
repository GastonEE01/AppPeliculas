using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.DTOs.FavoriteMovie
{
    public class FavoriteMovieUserResponseDto
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public double Qualification { get; set; }
    }
}
