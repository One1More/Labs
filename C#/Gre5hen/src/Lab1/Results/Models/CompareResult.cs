namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public abstract record CompareResult
{
    private CompareResult() { }

    public sealed record FirstSpaceshipBetter() : CompareResult;

    public sealed record SecondSpaceshipBetter() : CompareResult;

    public sealed record BothSpaceShipsUseless() : CompareResult;
}