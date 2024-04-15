using System;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.ShipHull.Models;

public class ThirdClassHull : IHull
{
    private int _hp;

    public ThirdClassHull()
    {
        _hp = 500;
    }

    public int Damage(IObstacle obstacle)
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
                _hp -= obstacle.DealDamage();
                break;
            default:
                throw new ArgumentException("Error: Unknown obstacle.");
        }

        return _hp;
    }
}