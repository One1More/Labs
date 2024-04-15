using Lab5.Application.Extensions;
using Lab5.Infrastracture.DataAccess.Extensions;
using Lab5.Presenation.Console;
using Lab5.Presenation.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 6432;
        configuration.Username = "postgres";
        configuration.Password = "postgres";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

ScriptRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScriptRunner>();

scope.UseInfrastructureDataAccess();

while (true)
{
    scenarioRunner.Run();
    AnsiConsole.Clear();
}