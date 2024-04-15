namespace Lab5.Application.Contracts.UserLogin;

public abstract record UserCheckBalanceResult
{
    private UserCheckBalanceResult() { }

    public sealed record Success(long Balance) : UserCheckBalanceResult;

    public sealed record WrongUser() : UserCheckBalanceResult;
}