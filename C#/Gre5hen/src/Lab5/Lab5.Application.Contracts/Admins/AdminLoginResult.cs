namespace Lab5.Application.Contracts.AdminLogin;

public abstract record AdminLoginResult
{
    private AdminLoginResult() { }

    public sealed record Success() : AdminLoginResult;

    public sealed record WrongCode() : AdminLoginResult;
}