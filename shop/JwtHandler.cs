using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace shop
{
    public class JwtHandler
    {
        private readonly IConfiguration _configuration;

        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(ShopUser user)
        {
            var jwtSettings = _configuration.GetSection("JWTSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Name, user.UserId.ToString()),
                // Add more claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(jwtSettings["expiryInMinutes"])),
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = GenerateRandomKey();
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private byte[] GenerateRandomKey()
        {
            byte[] key = new byte[32]; 
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }
    }
}
