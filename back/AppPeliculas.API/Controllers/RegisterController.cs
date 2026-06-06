using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace AppPeliculas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        public readonly CreateUserUseCase _createUserUseCase;

        public RegisterController(CreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public IActionResult Register([FromBody] UserDtoRequest dto)
        {
            try
            {
                var register = _createUserUseCase.CreateUser(dto);
                return Ok(register);
            }
            catch (Exception ex)
            {
                return NotFound(new
                {
                    message = ex.Message
                });
            }
        }
    }
}
