using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.DTOs.User
{
    public class LoginDtoResponse
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

    }
}
