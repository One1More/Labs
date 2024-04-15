using Lab5.Application.Contracts.UserLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.UserLogin;

public class UserLoginScript : IScript
{
    private readonly IUserService _service;

    public UserLoginScript(IUserService service)
    {
        _service = service;
    }

    public string Name => "User";

    public void Run()
    {
        int number = AnsiConsole.Ask<int>("Enter your account number:");

        if (_service.CheckAccount(number) is UserAccountFindResult.Success)
        {
            TextPrompt<int> prompt = new TextPrompt<int>("Enter your PIN code:")
                .PromptStyle("red")
                .Secret();
            int pinCode = AnsiConsole.Prompt(prompt);

            UserLoginResult result = _service.Login(pinCode, number);
            string resultMessage = result switch
            {
                UserLoginResult.Success => "\nPIN code is coorect. Successful login.",
                UserLoginResult.Fail => "\nPIN code is wrong. Check your data.",
                _ => throw new ArgumentOutOfRangeException(nameof(result)),
            };
            AnsiConsole.WriteLine(resultMessage);

            AnsiConsole.WriteLine("\nPush any key to continue");
            System.Console.ReadKey();

            AnsiConsole.WriteLine(resultMessage);
        }
        else
        {
            AnsiConsole.WriteLine("\nAccount not found.");
            AnsiConsole.WriteLine("\nPush any key to continue");
            System.Console.ReadKey();
        }
    }
}