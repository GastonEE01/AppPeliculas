using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Domain.Entities;
using Moq;
using Xunit;

namespace AppPeliculas.Test;

public class GetMoviesUseCaseTest
{
    [Fact]
    public void GetMovies_ShouldReturnMovie_WhenMovieExists()
    {
        // Arrange
        var movieRepositoryMock = new Mock<IMovieIRepository>();

        var movie = new Movie
        {
            Id = 1,
            Title = "Terminator",
            Category = "Accion",
            Description = "Test",
            Qualification = 5,
            IMG = ""
        };

        movieRepositoryMock
            .Setup(x => x.GetById(1))
            .Returns(movie);

        var useCase = new GetMoviesUseCase(movieRepositoryMock.Object);

        // Act
        var result = useCase.GetMovies(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(movie.Id, result.Id);
        Assert.Equal(movie.Title, result.Title);
    }

    [Fact]
    public void GetMovies_ShouldThrowException_WhenIdIsInvalid()
    {
        // Arrange
        var movieRepositoryMock = new Mock<IMovieIRepository>();

        var useCase = new GetMoviesUseCase(movieRepositoryMock.Object);

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            useCase.GetMovies(0);
        });
    }

    [Fact]
    public void GetMovies_ShouldThrowException_WhenMovieDoesNotExist()
    {
        // Arrange
        var movieRepositoryMock = new Mock<IMovieIRepository>();

        movieRepositoryMock
            .Setup(x => x.GetById(1))
            .Returns((Movie)null);

        var useCase = new GetMoviesUseCase(movieRepositoryMock.Object);

        // Act & Assert
        Assert.Throws<Exception>(() =>
        {
            useCase.GetMovies(1);
        });
    }
}
