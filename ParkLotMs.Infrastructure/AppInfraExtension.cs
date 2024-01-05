using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Services;
using ParkLotMs.DataAccess.DbAccess;
using ParkLotMs.Infrastructure.Authentication;

namespace ParkLotMs.Infrastructure;

public static class AppInfraExtension
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
