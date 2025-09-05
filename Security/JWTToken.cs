using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace pojokkamera_backend.Security
{
    public class JWTToken
    {
        // Method diubah menjadi public static
        public static string GenerateUserJWTAccessToken(string Id, string Email, string Username)
        {
            // ⚠️ Peringatan: Hardcoding secret key seperti ini sangat tidak aman!
            var secret = Environment.GetEnvironmentVariable("JWTSK_USER_ACCESSTOKEN");
            if (string.IsNullOrEmpty(secret))
                throw new Exception("JWT secret tidak ditemukan di environment variables!");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, Id),
            new Claim(JwtRegisteredClaimNames.Email, Email),
            new Claim(JwtRegisteredClaimNames.UniqueName, Username)
        };

            var token = new JwtSecurityToken(
                issuer: "yourapp.com",
                audience: "yourapp.com",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Cara memanggilnya:
    // var tokenString = JWTToken.GenerateJwtToken(userObject);
}