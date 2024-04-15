using Itmo.ObjectOrientedProgramming.Lab1.Deflector.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ShipHull.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;

public class Avgur : IShip
{
    private readonly EClassEngine _engine;
    private readonly JumpEngineAlpha _jumpEngine;
    private readonly ThirdClassDeflector _deflector;
    private readonly ThirdClassHull _hull;
    private readonly PhotonDeflector _photonDefelctor;

    public Avgur(EClassEngine engine, JumpEngineAlpha jumpengine, ThirdClassDeflector deflector, ThirdClassHull hull, PhotonDeflector photon)
    {
        _engine = engine;
        _jumpEngine = jumpengine;
        _deflector = deflector;
        _hull = hull;
        _photonDefelctor = photon;
        AllUsedFuel = 0;
    }

    public int AllUsedFuel { get; private set; }

    public void MadePhotonModification()
    {
        _photonDefelctor.MadePhotonModification();
    }

    public int TakeDeflectorDamage(IObstacle obstacle)
    {
        return _deflector.TakeDamage(obstacle);
    }

    public int TakeHullDamage(IObstacle obstacle)
    {
        return _hull.Damage(obstacle);
    }

    public int TakeAntimatterDamage()
    {
        return _photonDefelctor.AntimatterDamage();
    }

    public IEngine CheckJumpEngineType()
    {
        return _jumpEngine;
    }

    public int UsedFuel(int distance)
    {
        return _engine.EngineFuelUsage(distance);
    }

    public int JumpedUsedFuel(int distance)
    {
        return _jumpEngine.EngineFuelUsage(distance);
    }

    public void SetUsedFuel(int fuelUsage)
    {
        AllUsedFuel += fuelUsage;
    }

    public bool UseJumpEngine(int distance)
    {
        return _jumpEngine.CanPassNebulaeDistance(distance);
    }
}