using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Users;

namespace Lab5.Presenation.Console.Scenarios.UserWithdrawingMoney;

public class UserWithdrawMoneyScriptProvider : IScriptProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUser _currentUser;

    public UserWithdrawMoneyScriptProvider(IUserService service, ICurrentUser currentUser)
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

        script = new UserWithdrawingMoneyScript(_service);

        return true;
    }
}