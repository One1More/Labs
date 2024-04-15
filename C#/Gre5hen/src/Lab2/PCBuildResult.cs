using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public abstract record PCBuildResult
{
    private PCBuildResult() { }

    public sealed record Success(PC.PC Pc) : PCBuildResult;

    public sealed record Fail(IEnumerable<CompareResult> CompareResult) : PCBuildResult;
}