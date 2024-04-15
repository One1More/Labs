using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull.Models;

public interface IHull
{
    int Damage(IObstacle obstacle);
}