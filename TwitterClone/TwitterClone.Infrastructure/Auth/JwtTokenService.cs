using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private JsonWebTokenHandler _jwtHandler = new JsonWebTokenHandler();

        public JwtTokenService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public (string, DateTime) GetToken(UserDto user)
        {

            // business logic to return token with expiry time.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                // Can Add more claims here if needed, like roles, permissions, etc.
            };

            var expiryTime = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTimeInMinutes);

            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var descriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expiryTime,
                SigningCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256)
            };

            return (_jwtHandler.CreateToken(descriptor), expiryTime);
        }
    }
}
