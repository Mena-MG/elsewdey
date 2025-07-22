// --- File: Repos/JwtService.cs ---

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RegisterAPII.Interfaces;
using RegisterAPII.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RegisterAPII.Repos
{
    public class JwtService : IJwtService
    {
        private readonly string _key;

        // تم تمرير المفتاح من الـ Configuration أو مباشرة من الـ Startup
        public JwtService(string key)
        {
            _key = key;
        }

        public string GenerateToken(Accounts user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role?.Name ?? "User") // معالجة الـ null
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
