﻿using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Models;
using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Infrastracture.DataAccess.Plugins;
using Lab5.Infrastracture.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Infrastracture.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDataAccess(
        this IServiceCollection collection,
        Action<PostgresConnectionConfiguration> configuration)
    {
        collection.AddPlatformPostgres(builder => builder.Configure(configuration));
        collection.AddPlatformMigrations(typeof(ServiceCollectionExtensions).Assembly);

        collection.AddSingleton<IDataSourcePlugin, MuppingPlugin>();

        collection.AddScoped<IUserRepository, UserRepository>();
        collection.AddScoped<IAdminRepository, AdminRepository>();

        return collection;
    }
}