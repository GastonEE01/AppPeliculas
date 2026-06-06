using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppPeliculas.API.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        public readonly CreateUserUseCase _createUserUseCase;
        public readonly IUserRepository _userRepository;
        public UserController(CreateUserUseCase createUserUseCase, IUserRepository userRepository)
        {
            _createUserUseCase = createUserUseCase;
            _userRepository = userRepository;

        }

          [HttpGet("Me")]  
          [Authorize]     
          public IActionResult GetCurrentUser()
          {
              // El JWT contiene el userId en los claims
              var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
              var user = _userRepository.GetById(Guid.Parse(userId));
              return Ok(user);
          }

       /* [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            return Ok(new
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                Name = User.FindFirst(ClaimTypes.Name)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value
            });
        }
       */
    }
}