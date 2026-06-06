using AppPeliculas.Application.Interfaces;
using AppPeliculas.Domain.Entities;
using AppPeliculas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }


        public bool ValidatePassword(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

        }

        public User? GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByIdWithFavorites(Guid id)
        {
            return _context.Users
                .Include(u => u.FavoriteMovies)
                .ThenInclude(f => f.Movie)
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
