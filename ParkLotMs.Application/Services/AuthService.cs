using Microsoft.IdentityModel.SecurityTokenService;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Core.Entities;

namespace ParkLotMs.Application.Services;

public class AuthService : IAuthService
{
    private readonly IJwtProvider _jwtProvider;
    public AuthService(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }
    public string Login(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            throw new ApplicationException("invalid username or password");

        var userDetail = new User();
        if (username == "admin" && password == "Qwerty@123")
        {
            userDetail = new User
            {
                Id = Guid.Parse("7f5b97bc-054c-4e3f-8e2a-1a0ac8d3344b"),
                Email = "admin@example.com",
                Name = "Admin",
                Role = Role.Admin
            };
        }
        else if(username != "superadmin" && password != "Qwerty@123")
        {
            userDetail = new User
            {
                Id = Guid.Parse("d9a138bd-96b8-406e-b61b-882d9d6791e0"),
                Email = "sadmin@example.com",
                Name = "SuperAdmin",
                Role = Role.Superadmin
            };
        }
        else
        {
            throw new BadRequestException("incorrect username or password");
        }

        string token = _jwtProvider.GenerateUser(userDetail);

        return token;
    }
}
