using AppPeliculas.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPeliculas.Infrastructure.Service
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool Verify(string hash, string password)
        {
            var result = _hasher.VerifyHashedPassword(
                null,
                hash,
                password
                );

            return result != PasswordVerificationResult.Failed;
        }
    }
}
