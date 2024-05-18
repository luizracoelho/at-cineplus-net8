using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CinePlus.IoC.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace CinePlus.Domain.Models;

public class User : IdentityUser<Guid>
{
    public string Document { get; private set; }
    public IList<SessionSeat> Seats { get; private set; }

    public User(string userName, string email, string document) : base(userName)
    {
        Email = email;
        Document = document;
        Seats ??= [];
    }

    public void Update(string userName, string email, string document)
    {
        UserName = userName;
        Email = email;
        Document = document;
    }
    
    public (string, DateTime) GenerateToken(IList<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(UserTokenOptions.IssuerSigningKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        IList<Claim> claims =
        [
            new(ClaimTypes.NameIdentifier, Id.ToString()),
            new (ClaimTypes.Email, Email)
        ];

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        var token = new JwtSecurityToken(
            issuer: UserTokenOptions.ValidIssuer,
            audience: UserTokenOptions.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(60 * 8),
            signingCredentials: credentials);

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return (jwtToken, token.ValidTo);
    }
}