namespace Lab5.Application.Contracts.UserLogin;

public abstract record UserLoginResult
{
    private UserLoginResult() { }

    public sealed record Success() : UserLoginResult;

    public sealed record Fail() : UserLoginResult;
}