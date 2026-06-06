using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.DTOs.FavoriteMovie
{
    public class GetFavoriteUserDtoRequest
    {
        public Guid UserId { get; set; }
    }
}
