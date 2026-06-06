using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Domain.Entities
{
    public class MovieRating
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public Guid MovieId { get; set; }
        public Movie Movie { get; set; } = null!;

        public int Start { get; set; }
    }
}
