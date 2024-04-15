using Lab5.Application.Admins;
using Lab5.Application.Contracts.AdminLogin;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<IAdminService, AdminService>();

        collection.AddScoped<CurrentUser>();
        collection.AddScoped<ICurrentUser>(
            x => x.GetRequiredService<CurrentUser>());

        return collection;
    }
}