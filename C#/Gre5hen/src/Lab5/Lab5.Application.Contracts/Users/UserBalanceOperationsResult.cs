namespace Lab5.Application.Contracts.UserLogin;

public abstract record UserBalanceOperationsResult
{
    private UserBalanceOperationsResult() { }

    public sealed record Success() : UserBalanceOperationsResult;

    public sealed record InsufficientFunds() : UserBalanceOperationsResult;

    public sealed record MoneyLowerZero() : UserBalanceOperationsResult;
}