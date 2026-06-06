using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Domain.Entities
{
    public class FavoriteMovie
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }

        // Propiedades de navegación de EF Core (Clave para los Joins automáticos)
        public User User { get; set; } = null!;
        public Movie Movie { get; set; } = null!;

    }
}
