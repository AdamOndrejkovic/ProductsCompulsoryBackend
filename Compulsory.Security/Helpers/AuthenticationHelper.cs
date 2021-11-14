using System;
using System.IdentityModel.Tokens.Jwt;
using Compulsory.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace Compulsory.Security
{
    public class AuthenticationHelper: IAuthenticationHelper
    {
        private readonly byte[] _secretBytes;

        public AuthenticationHelper(Byte[] secret)
        {
            _secretBytes = secret;
        }
        
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        public string GenerateToken(Admin admin)
        {
            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(_secretBytes),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(null, null, null, DateTime.Now, DateTime.Now.AddMinutes(10))
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}