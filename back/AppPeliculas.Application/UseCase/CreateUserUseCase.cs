using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;

namespace AppPeliculas.Application.UseCase

{
    public class CreateUserUseCase
    {
        public IUserRepository _userRepository;
        public IPasswordService _passwordService;

        public CreateUserUseCase(IUserRepository userRepository,IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public User CreateUser(UserDtoRequest dto)
        {
            if (!dto.Email.Contains("@"))
                throw new ArgumentException("El Email debe llevar @");
            if (!dto.Email.Contains(".com"))
                throw new ArgumentException("El Email debe llevar .com");
            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("Es Email es requerido");

            if (dto.PasswordHash.Length <= 6)
                throw new ArgumentException("La contraseña debe tener almenos 6 carateres");

            var user = new User
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = _passwordService.Hash(dto.PasswordHash),
                ImgUrl = dto.ImgUrl,    
            };

            _userRepository.Add(user);
            return user;
        }
    }
}