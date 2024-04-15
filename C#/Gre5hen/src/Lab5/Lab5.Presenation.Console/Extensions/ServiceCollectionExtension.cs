using Lab5.Presenation.Console.Scenarios.AdminAddNewAcc;
using Lab5.Presenation.Console.Scenarios.AdminChangeSystemPassword;
using Lab5.Presenation.Console.Scenarios.AdministratorLogin;
using Lab5.Presenation.Console.Scenarios.ExitApp;
using Lab5.Presenation.Console.Scenarios.UserAddingMoney;
using Lab5.Presenation.Console.Scenarios.UserCheckBalance;
using Lab5.Presenation.Console.Scenarios.UserCheckHistory;
using Lab5.Presenation.Console.Scenarios.UserLogin;
using Lab5.Presenation.Console.Scenarios.UserWithdrawingMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presenation.Console.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScriptRunner>();

        collection.AddScoped<IScriptProvider, UserLoginScriptProvider>();
        collection.AddScoped<IScriptProvider, AdminLoginScriptProvider>();
        collection.AddScoped<IScriptProvider, UserCheckBalanceScriptProvider>();
        collection.AddScoped<IScriptProvider, AdminAddNewAccountScriptProvider>();
        collection.AddScoped<IScriptProvider, UserAddingMoneyScriptProvider>();
        collection.AddScoped<IScriptProvider, UserWithdrawMoneyScriptProvider>();
        collection.AddScoped<IScriptProvider, UserCheckHistoryProvider>();
        collection.AddScoped<IScriptProvider, AdminChangeSysPasswordScriptProvider>();
        collection.AddScoped<IScriptProvider, ExitScriptProvider>();

        return collection;
    }
}