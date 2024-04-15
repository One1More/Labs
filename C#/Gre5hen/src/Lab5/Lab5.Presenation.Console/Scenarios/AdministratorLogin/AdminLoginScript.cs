using Lab5.Application.Contracts.AdminLogin;
using Spectre.Console;

namespace Lab5.Presenation.Console.Scenarios.AdministratorLogin;

public class AdminLoginScript : IScript
{
    private readonly IAdminService _service;

    public AdminLoginScript(IAdminService service)
    {
        _service = service;
    }

    public string Name => "Admin";
    public void Run()
    {
        int code = AnsiConsole.Ask<int>("Enter admin code:");

        if (_service.Login(code) is not AdminLoginResult.Success)
        {
            Environment.Exit(0);
        }
    }
}