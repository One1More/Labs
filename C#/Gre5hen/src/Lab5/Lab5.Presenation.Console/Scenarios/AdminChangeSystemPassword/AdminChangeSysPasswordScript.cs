using Lab5.Application.Contracts.AdminLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.AdminChangeSystemPassword;

public class AdminChangeSysPasswordScript : IScript
{
    private readonly IAdminService _service;

    public AdminChangeSysPasswordScript(IAdminService service)
    {
        _service = service;
    }

    public string Name => "Change system password.";
    public void Run()
    {
        int code = AnsiConsole.Ask<int>("Enter new admin code:");

        _service.ChangeSystemPassword(code);

        AnsiConsole.WriteLine("\nOperation has done successfully!");
        System.Console.ReadKey();
    }
}