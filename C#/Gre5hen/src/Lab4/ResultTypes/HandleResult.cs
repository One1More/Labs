using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

public abstract record HandleResult
{
    private HandleResult() { }

    public sealed record Fail() : HandleResult;

    public sealed record Success(ICommand Command) : HandleResult;
}