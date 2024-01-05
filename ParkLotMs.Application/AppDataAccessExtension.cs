using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Services;
using ParkLotMs.DataAccess.DbAccess;

namespace ParkLotMs.Application;

public static class AppDataAccessExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ISqlDataAccess, SqlDataAccess>(options => new SqlDataAccess(configuration));
        services.AddScoped<IVehicleTypeService, VehicleTypeService>();
        services.AddScoped<IParkingAreaServices, ParkingAreaServices>();
        services.AddScoped<IParkingBillingServices, ParkingBillingServices>();

        return services;
    }
}
