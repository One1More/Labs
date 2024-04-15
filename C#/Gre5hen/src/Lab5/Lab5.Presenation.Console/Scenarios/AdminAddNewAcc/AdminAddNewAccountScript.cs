using Lab5.Application.Contracts.AdminLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.AdminAddNewAcc;

public class AdminAddNewAccountScript : IScript
{
    private readonly IAdminService _service;

    public AdminAddNewAccountScript(IAdminService service)
    {
        _service = service;
    }

    public string Name => "Add new bank account";
    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Write new bank account number:");
        int pinCode = AnsiConsole.Ask<int>("Write pin code to new account:");

        _service.CreateNewBancAccount(number, pinCode);
    }
}