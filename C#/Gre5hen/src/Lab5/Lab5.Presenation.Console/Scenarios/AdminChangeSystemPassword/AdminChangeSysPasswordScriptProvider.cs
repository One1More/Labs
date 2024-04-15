using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.AdminLogin;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Users;

namespace Lab5.Presenation.Console.Scenarios.AdminChangeSystemPassword;

public class AdminChangeSysPasswordScriptProvider : IScriptProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUser _currentUser;

    public AdminChangeSysPasswordScriptProvider(ICurrentUser currentUser, IAdminService service)
    {
        _currentUser = currentUser;
        _service = service;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScript? script)
    {
        if (_currentUser.User is null || _currentUser.User.Role is UserRole.User)
        {
            script = null;

            return false;
        }

        script = new AdminChangeSysPasswordScript(_service);

        return true;
    }
}