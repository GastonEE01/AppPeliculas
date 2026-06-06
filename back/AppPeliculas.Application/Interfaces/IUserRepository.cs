using AppPeliculas.Domain.Entities;

namespace AppPeliculas.Application.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        User GetByEmail(string email);
        User? GetById(Guid guid);
        User? GetByIdWithFavorites(Guid id);

        bool ValidatePassword(User user,string passwordHash);
    }
}