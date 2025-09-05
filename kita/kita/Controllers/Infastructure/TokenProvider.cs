using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace kita.Controllers.Infastructure;

public class TokenProvider(IConfiguration configuration)
{
    public string Create(User user)
    {
        string key = configuration["Jwt:Secret"] ?? throw new InvalidOperationException("JWT Secret not found in configuration.");
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("id", user.Id.ToString()),
                // new Claim("email", user.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credentials,
            Issuer = configuration["Jwt:Issuer"],
            Audience = configuration["Jwt:Audience"]
        };
        var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}