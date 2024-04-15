namespace Lab5.Application.Models.Operations;

public class WithdrawalOperation : IUserOperation
{
    public WithdrawalOperation(long money)
    {
        Money = money;
        CurrentUserOperation = Operation.Withdrawal;
    }

    public long Money { get; }
    public Operation CurrentUserOperation { get; }

    public void Show()
    {
        Console.WriteLine(Money + " was withdrawn from the account");
    }
}