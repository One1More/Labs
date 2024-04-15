using Lab5.Application.Contracts.UserLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.UserCheckBalance;

public class UserCheckBalanceScript : IScript
{
    private readonly IUserService _service;

    public UserCheckBalanceScript(IUserService service)
    {
        _service = service;
    }

    public string Name => "Check account balance";

    public void Run()
    {
        if (_service.CheckAccountBalance() is UserCheckBalanceResult.Success res)
        {
            AnsiConsole.WriteLine("Your balance is " + res.Balance);
        }
        else
        {
            AnsiConsole.WriteLine("Something went wrong. Check account number");
        }

        AnsiConsole.WriteLine("\nPush any key to continue");
        System.Console.ReadKey();
    }
}