using Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;

public class Shuttle : IShip
{
    private readonly CClassEngine _engine;
    private readonly FirstClassHull _hull;

    public Shuttle(CClassEngine engine, FirstClassHull hull)
    {
        _engine = engine;
        _hull = hull;
        AllUsedFuel = 0;
    }

    public int AllUsedFuel { get; private set; }

    public int TakeHullDamage(IObstacle obstacle)
    {
        return _hull.Damage(obstacle);
    }

    public int UsedFuel(int distance)
    {
        return _engine.EngineFuelUsage(distance);
    }

    public int TakeDeflectorDamage(IObstacle obstacle)
    {
        return -1;
    }

    public IEngine? CheckJumpEngineType()
    {
        return null;
    }

    public int TakeAntimatterDamage()
    {
        return -1;
    }

    public int JumpedUsedFuel(int distance)
    {
        return 0;
    }

    public void SetUsedFuel(int fuelUsage)
    {
        AllUsedFuel += fuelUsage;
    }

    public bool UseJumpEngine(int distance)
    {
        return false;
    }
}