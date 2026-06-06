using AppPeliculas.API.Controllers;
using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Domain.Entities;
using Moq;
using Xunit;

namespace AppPeliculas.Test;

public class CreateUserUseCaseTest
{
    [Fact]
    public void CreateUser_ShouldThrowException_WhenPasswordIsEmpty()
    {
        // Arrange 

        var userRepository = new Mock<IUserRepository>();
        var passwordRepository = new Mock<IPasswordService>();

        var useCase = new CreateUserUseCase(userRepository.Object, passwordRepository.Object);

        var user = new UserDtoRequest
        {
            Name = "Gaston",
            Email = "estevezgaston01@gmail.com",
            Id = 1,
            PasswordHash = ""
        };

        // Assert

        Assert.Throws<ArgumentException>(() =>
        {
            useCase.CreateUser(user);
        });


    }

    [Fact]
    public void CreateUser_ShouldCreateUser_WhenDataIsValid()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        var passwordServiceMock = new Mock<IPasswordService>();

        passwordServiceMock
            .Setup(x => x.Hash(It.IsAny<string>()))
            .Returns("hashedPassword");

        var useCase = new CreateUserUseCase(
            userRepositoryMock.Object,
            passwordServiceMock.Object
        );

        var user = new UserDtoRequest
        {
            Name = "Gaston",
            Email = "gaston@gmail.com",
            PasswordHash = "1234567"
        };

        // Act
        var result = useCase.CreateUser(user);

        // Assert
        Assert.NotNull(result);

        userRepositoryMock.Verify(
            x => x.Add(It.IsAny<User>()),
            Times.Once
        );
    }
    [Fact]
        public void Test_Que_Siempre_Da_True()
        {
            // Arrange
            var numero = 5;

            // Act
            var resultado = numero + 5;

            // Assert
            Assert.Equal(10, resultado);
        }
    
}
