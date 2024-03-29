﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkLotMs.Core;

namespace ParkLotMs.Persistence;

public static class DbAppExtension
{
    public static IServiceCollection AddDatabasePostgreSQL(this IServiceCollection services, IConfiguration configuration, string connectionName = "DefaultConnection")
    {
        services.AddDbContext<ParkingLotContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(connectionName), npgOption =>
            {
                npgOption.CommandTimeout(30);
                npgOption.EnableRetryOnFailure(3);
            });
        });

        return services;
    }
}