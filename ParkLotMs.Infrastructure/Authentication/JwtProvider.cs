using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkLotMs.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    public JwtProvider(IOptions<JwtOptions> options)
    {
        _jwtOptions = options.Value;
    }

    public string GenerateUser(User user)
    {
        var claims = new Claim[] { 
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Sub, user.Role.ToString())};

        var signingCred = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_jwtOptions.Issueer,
            _jwtOptions.Audience,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(30),
            signingCred);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}
