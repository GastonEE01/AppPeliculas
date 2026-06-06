using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppPeliculas.API.Controllers
{
    [ApiController]
   // [Authorize]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        public readonly ITokenService _tokenService;
        public readonly LoginUseCase _loginUseCase;
        public LoginController(LoginUseCase loginUseCase, ITokenService tokenService)
        {
            _loginUseCase = loginUseCase;
            _tokenService = tokenService;
        }

        [HttpPost()]
        public IActionResult Login([FromBody]LoginDtoRequest dto)
        {
            try
            {
                var user = _loginUseCase.ValidateUser(dto);

                var token = _tokenService.GenerateToken(user);

                var response = new LoginDtoResponse
                {

                    Token = token,
                    Email = user.Email,
                    Name = user.Name
                };

                return Ok(response);
            } 
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message
                });
            }
        }


    }
}
