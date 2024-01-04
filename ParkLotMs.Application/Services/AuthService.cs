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

        if (username != "admin" || password != "Qwerty@123")
            throw new ApplicationException("incorrect username or password");

        string token = _jwtProvider.GenerateUser(new User {
            
        });
        return token;
    }
}
