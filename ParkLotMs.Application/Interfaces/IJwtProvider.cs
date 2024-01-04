using ParkLotMs.Core.Entities;

namespace ParkLotMs.Application.Interfaces;

public interface IJwtProvider
{
    string GenerateUser(User user);
}
