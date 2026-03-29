using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models.DTOs;
using TaskManagerAPI.Models.DTOs.Auth;
using TaskManagerAPI.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace TaskManagerAPI.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserEntity?> RegisterAsync(RegisterDto dto)
        {
            // Verificar si el usuario existe
            var exists = await _context.User.AnyAsync(u => u.Username == dto.Username);

            if (exists)
                return null;

            // Hashear contraseña
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new UserEntity
            {
                Username = dto.Username,
                PasswordHash = passwordHash
            };

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.User
                .FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (user == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isValid)
                return null;

            // 🔑 Generar token (lo haremos en el siguiente paso)
            return GenerateJwtToken(user);
        }
        private string GenerateJwtToken(UserEntity user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username)
             };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
