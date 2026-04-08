using Microsoft.IdentityModel.Tokens;
using SmartFieldService.Application.DTOs;
using SmartFieldService.Application.Interfaces;
using SmartFieldService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartFieldService.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _key = "THIS_IS_A_VERY_LONG_SUPER_SECRET_KEY_123456";

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            // Dummy user (later replace with DB)
            if (request.Email != "test@test.com" || request.Password != "123456")
                return null;

            var user = new User
            {
                Id = 1,
                Email = request.Email
            };

            var token = GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                UserId = user.Id,
                Name = "Test User"
            };
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}