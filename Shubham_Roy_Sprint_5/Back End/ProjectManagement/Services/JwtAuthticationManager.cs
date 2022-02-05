using Domain.Entities;
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

        private readonly List<User> adminUsers = new List<User>()
        {
            new User{ ID = 420, FirstName = "SuperAdmin1", LastName = "", Password = "SuperPwd1", Email = "SuperAdmin1@projman.com"},
            new User{ ID = 420, FirstName = "SuperAdmin2", LastName = "", Password = "SuperPwd2", Email = "SuperAdmin2@projman.com"}
        };

        public JwtAuthticationManager(string key)
        {
            this.key = key;
        }

        public string Authenticate(User loginAdminUser)
        {
            if (!adminUsers.Any(user => user.Email == loginAdminUser.Email && user.Password == loginAdminUser.Password))
            {
                return null;
            }
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddHours(12),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, loginAdminUser.Email)
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}