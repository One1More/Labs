using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.UserLogin;

namespace Lab5.Presenation.Console.Scenarios.UserLogin;

public class UserLoginScriptProvider : IScriptProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUser _currentUser;

    public UserLoginScriptProvider(IUserService service, ICurrentUser currentUser)
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

        script = new UserLoginScript(_service);

        return true;
    }
}