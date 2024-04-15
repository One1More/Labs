using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Users;

namespace Lab5.Presenation.Console.Scenarios.UserCheckBalance;

public class UserCheckBalanceScriptProvider : IScriptProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUser _currentUser;

    public UserCheckBalanceScriptProvider(IUserService service, ICurrentUser currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScript? script)
    {
        if (_currentUser.User is null || _currentUser.User.Role is UserRole.Admin)
        {
            script = null;

            return false;
        }

        script = new UserCheckBalanceScript(_service);

        return true;
    }
}