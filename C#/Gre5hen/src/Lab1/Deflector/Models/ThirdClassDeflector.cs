using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector.Models;

public class ThirdClassDeflector : IDeflector
{
    private int _hp;

    public ThirdClassDeflector()
    {
        _hp = 1000;
    }

    public int TakeDamage(IObstacle obstacle)
    {
        switch (obstacle.DealDamage())
        {
            case <= 1000:
                _hp -= (int)(obstacle.DealDamage() * 0.025);
                break;
            case <= 2000:
                _hp -= (int)(obstacle.DealDamage() * 0.05);
                break;
            case <= 3000:
                _hp -= (int)(obstacle.DealDamage() * 0.333);
                break;
            default:
                throw new ArgumentException("Error: Unknown obstacle.");
        }

        return _hp;
    }
}