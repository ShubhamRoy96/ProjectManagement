using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.Services
{
    public class JwtAuthticationManager : IJwtAuthenticationManager
    {
        private readonly string key;

        private readonly Dictionary<string, string> adminUsers = new Dictionary<string, string>()
        {
            {"SuperAdmin1", "SuperPwd1" },
            {"SuperAdmin2", "SuperPwd2" }
        };

        public JwtAuthticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(string username, string password)
        {
            if (!adminUsers.Any(user => user.Key == username && user.Value == password))
            {
                return null;
            }
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddHours(12),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}