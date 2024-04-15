using Lab5.Application.Contracts.UserLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.UserWithdrawingMoney;

public class UserWithdrawingMoneyScript : IScript
{
    private readonly IUserService _service;

    public UserWithdrawingMoneyScript(IUserService service)
    {
        _service = service;
    }

    public string Name => "Make a withdrawal.";
    public void Run()
    {
        long deposit = AnsiConsole.Ask<long>("How much would you like to withdraw from your account");

        switch (_service.MakeWithdrawal(deposit))
        {
            case UserBalanceOperationsResult.Success:
                AnsiConsole.WriteLine("Operation done successfully");
                break;
            case UserBalanceOperationsResult.InsufficientFunds:
                AnsiConsole.WriteLine("You haven't got enough money");
                break;
            case UserBalanceOperationsResult.MoneyLowerZero:
                AnsiConsole.WriteLine("You cannot withdraw 0 or negative amount of money.");
                break;
        }

        AnsiConsole.WriteLine("\nPush any key to continue");
        System.Console.ReadKey();
    }
}