using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.DTOs.FavoriteMovie
{
    public class AddFavoriteDtoRequest
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
    }
}
