using Lab5.Application.Contracts.UserLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.UserCheckHistory;

public class UserCheckHistoryScript : IScript
{
    private readonly IUserService _service;

    public UserCheckHistoryScript(IUserService service)
    {
        _service = service;
    }

    public string Name => "Look operations history.";
    public void Run()
    {
        _service.CheckOperationHistory().Show();

        AnsiConsole.WriteLine("\nPush any key to continue");
        System.Console.ReadKey();
    }
}