using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Application.UseCase
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordService _passwordService;

        public LoginUseCase(IUserRepository userRepository,ITokenService tokenService, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordService = passwordService; 
        }

        public User ValidateUser(LoginDtoRequest dto)
        {
            var user = _userRepository.GetByEmail(dto.Email);

            if (user == null)
                throw new Exception("Usuario no existe");

            var validPassword = _passwordService.Verify(user.PasswordHash, dto.Password);
            
            if (!validPassword)
                throw new Exception("Contraseña incorrecta");

            return user;
        }

    }
}
