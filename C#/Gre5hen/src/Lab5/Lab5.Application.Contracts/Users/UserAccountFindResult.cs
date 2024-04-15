namespace Lab5.Application.Contracts.UserLogin;

public abstract record UserAccountFindResult
{
    private UserAccountFindResult() { }

    public sealed record Success() : UserAccountFindResult;

    public sealed record NotFound() : UserAccountFindResult;
}