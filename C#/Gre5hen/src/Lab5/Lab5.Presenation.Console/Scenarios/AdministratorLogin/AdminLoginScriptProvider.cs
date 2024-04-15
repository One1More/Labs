using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.AdminLogin;
using Lab5.Application.Contracts.UserLogin;

namespace Lab5.Presenation.Console.Scenarios.AdministratorLogin;

public class AdminLoginScriptProvider : IScriptProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUser _currentUser;

    public AdminLoginScriptProvider(IAdminService service, ICurrentUser currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScript? script)
    {
        if (_currentUser.User is not null)
        {
            script = null;

            return false;
        }

        script = new AdminLoginScript(_service);

        return true;
    }
}