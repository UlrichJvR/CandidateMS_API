using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CandidateManagementSystem.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly string _key;

    public AuthenticationService(IConfiguration configuration)
    {
        _key = configuration["Jwt:SecretKey"];
    }

    public Task<string> GenerateJwtToken(Guid userId, string userName, string role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_key);

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            Issuer = "https://localhost:5144",
            Audience = "https://localhost:5144", 
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescription);
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}