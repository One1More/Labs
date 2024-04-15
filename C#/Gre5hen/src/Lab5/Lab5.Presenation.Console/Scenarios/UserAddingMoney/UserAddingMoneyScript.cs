using Lab5.Application.Contracts.UserLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.UserAddingMoney;

public class UserAddingMoneyScript : IScript
{
    private readonly IUserService _service;

    public UserAddingMoneyScript(IUserService service)
    {
        _service = service;
    }

    public string Name => "Make deposit.";
    public void Run()
    {
        long deposit = AnsiConsole.Ask<long>("How much would you like to add to your account");

        switch (_service.MakeDeposit(deposit))
        {
            case UserBalanceOperationsResult.Success:
                AnsiConsole.WriteLine("Operation done successfully");
                break;
            case UserBalanceOperationsResult.InsufficientFunds:
                AnsiConsole.WriteLine("You haven't got enough money");
                break;
            case UserBalanceOperationsResult.MoneyLowerZero:
                AnsiConsole.WriteLine("You cannot deposit 0 or negative amount of money.");
                break;
        }

        AnsiConsole.WriteLine("\nPush any key to continue");
        System.Console.ReadKey();
    }
}