using JwtAuth4Layered.Domain.Entities;
using JwtAuth4Layered.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuth4Layered.Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly string _secretKey;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _secretKey = configuration["JwtSettings:Secret"];
        }

        public async Task<string> AuthenticateAsync(string correo, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(correo);
            if (user == null || !VerifyPasswordHash(password, user.Password))
            {
                return null;
            }

            return GenerateJwtToken(user);
        }

        private bool VerifyPasswordHash(string password, string storedHash)
        {
            // Implementar verificación de hash de la contraseña
            if(password == storedHash) {
                return true;
            }
            return false;
        }

        private string GenerateJwtToken(Cliente cliente)
        {
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, cliente.Correo)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = "JwtAuth4Layered", // Define your issuer
                Audience = "JwtAuth4LayeredUsers", // Define your audience
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
