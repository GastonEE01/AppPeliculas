using AppPeliculas.API.Controllers;
using AppPeliculas.Application.DTOs.User;
using AppPeliculas.Application.Interfaces;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Domain.Entities;
using AppPeliculas.Infrastructure.Repositories;
using Moq;
using Xunit;

namespace AppPeliculas.Test;

public class AddFavoriteMovieUseCaseTest
{
    
    [Fact]
    public void AddFavoriteMovie_ShouldAddMovie_WhenDataIsValid()
    {
        // Arrange
        var favoriteMovieRepositoryMock = new Mock<IFavoriteMovieRepository>();

        var useCase = new AddFavoriteMovieUseCase(
            favoriteMovieRepositoryMock.Object
        );

        // Act
        useCase.AddFavorite(1, 1);

        // Assert
        favoriteMovieRepositoryMock.Verify(
            x => x.add(It.IsAny<FavoriteMovie>()),
            Times.Once
        );
    }

    [Fact]
    public void AddFavoriteMovie_ShouldReturnFavoriteMovie()
    {
        // Arrange
        var favoriteMovieRepositoryMock = new Mock<IFavoriteMovieRepository>();

        var useCase = new AddFavoriteMovieUseCase(
            favoriteMovieRepositoryMock.Object
        );

        // Act
        var result = useCase.AddFavorite(1, 2);

        // Assert
        Assert.NotNull(result);

        Assert.Equal(1, result.UserId);
        Assert.Equal(2, result.MovieId);
    }

    [Fact]
    public void AddFavoriteMovie_ShouldCallRepositoryOnce()
    {
        // Arrange
        var favoriteMovieRepositoryMock = new Mock<IFavoriteMovieRepository>();

        var useCase = new AddFavoriteMovieUseCase(
            favoriteMovieRepositoryMock.Object
        );

        // Act
        useCase.AddFavorite(1, 1);

        // Assert
        favoriteMovieRepositoryMock.Verify(
            x => x.add(It.IsAny<FavoriteMovie>()),
            Times.Once
        );
    }
}
