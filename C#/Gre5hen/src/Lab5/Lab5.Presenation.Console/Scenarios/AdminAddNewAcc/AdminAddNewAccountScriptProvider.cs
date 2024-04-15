using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.AdminLogin;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Users;

namespace Lab5.Presenation.Console.Scenarios.AdminAddNewAcc;

public class AdminAddNewAccountScriptProvider : IScriptProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUser _currentUser;

    public AdminAddNewAccountScriptProvider(IAdminService service, ICurrentUser currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScript? script)
    {
        if (_currentUser.User is null || _currentUser.User.Role is UserRole.User)
        {
            script = null;

            return false;
        }

        script = new AdminAddNewAccountScript(_service);

        return true;
    }
}