using Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;

public interface IShip
{
    int TakeHullDamage(IObstacle obstacle);
    int UsedFuel(int distance);
    int TakeDeflectorDamage(IObstacle obstacle);
    int TakeAntimatterDamage();
    IEngine? CheckJumpEngineType();
    int JumpedUsedFuel(int distance);
    void SetUsedFuel(int fuelUsage);
    bool UseJumpEngine(int distance);
}