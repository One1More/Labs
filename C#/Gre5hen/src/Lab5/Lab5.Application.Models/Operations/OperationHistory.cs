namespace Lab5.Application.Models.Operations;

public class OperationHistory : IUserOperation
{
    private readonly List<IUserOperation> _operations;

    public OperationHistory(IEnumerable<IUserOperation> operations)
    {
        _operations = operations.ToList();
    }

    public void Show()
    {
        foreach (IUserOperation operation in _operations)
        {
            operation.Show();
        }
    }
}