using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.DTOs.User
{
    public class LoginDtoRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
