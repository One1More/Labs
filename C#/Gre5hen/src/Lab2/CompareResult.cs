namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record CompareResult
{
    private CompareResult() { }

    public sealed record Success : CompareResult;

    public sealed record Fail(string FirstComp, string SecondComp, string Problem) : CompareResult;
}