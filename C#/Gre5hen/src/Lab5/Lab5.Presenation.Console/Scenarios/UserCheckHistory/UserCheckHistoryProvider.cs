using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Users;

namespace Lab5.Presenation.Console.Scenarios.UserCheckHistory;

public class UserCheckHistoryProvider : IScriptProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUser _currentUser;

    public UserCheckHistoryProvider(IUserService service, ICurrentUser currentUser)
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

        script = new UserCheckHistoryScript(_service);

        return true;
    }
}