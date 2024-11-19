using Core.Interfaces.Services;
using Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services;

public class AuthService : IAuthService
{
    //private readonly string _secretKey;

    //public AuthService(string secretKey)
    //{
    //    _secretKey = secretKey;
    //}

    public string CreateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var privateKey = Encoding.UTF8.GetBytes(JwtConfig.Secret);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(privateKey), SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //Subject = new ClaimsIdentity(new[]
            //{
            //    new Claim(ClaimTypes.Name, UserName),
            //    new Claim(ClaimTypes.Role, Role)
            //}),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credentials,
            Subject = GenerateClaims(user)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public static ClaimsIdentity GenerateClaims(User user)
    {
        var claims = new ClaimsIdentity();

        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
        claims.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

        foreach(var roles in user.Roles)
        {
            claims.AddClaim(new Claim(ClaimTypes.Role, roles));
        }

        return claims;
    }

    public string GenerateToken(User user)
    {
        throw new NotImplementedException();
    }
}
