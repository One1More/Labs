namespace Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

public abstract record ExpeditionResult
{
    private ExpeditionResult() { }

    public sealed record Success : ExpeditionResult;

    public sealed record SpaceshipDistruction : ExpeditionResult;

    public sealed record LostSpaceship : ExpeditionResult;

    public sealed record TheCrewIsDead : ExpeditionResult;
}