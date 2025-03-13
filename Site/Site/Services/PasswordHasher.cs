using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Site.Models;

namespace Site.Services
{
    public class PasswordHasher
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public PasswordHasher()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

 
        public string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

       
        public bool VerifyPassword(string hashedPassword, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
