namespace Lab5.Application.Models.Operations;

public class DepositOperation : IUserOperation
{
    public DepositOperation(long money)
    {
        Money = money;
        CurrentUserOperation = Operation.Deposit;
    }

    public long Money { get; }
    public Operation CurrentUserOperation { get; }

    public void Show()
    {
        Console.WriteLine("The account was topped up by " + Money);
    }
}