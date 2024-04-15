using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector.Models;

public interface IDeflector
{
    int TakeDamage(IObstacle obstacle);
}