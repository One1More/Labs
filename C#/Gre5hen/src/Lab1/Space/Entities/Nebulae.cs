using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;

public class Nebulae : ISpace
{
    private int _distance;
    private List<IObstacle> obstacles = new List<IObstacle>();

    public Nebulae(int dist)
    {
        _distance = dist;
    }

    public Nebulae(int dist, int numberOfObstacles)
    {
        _distance = dist;

        for (int i = 0; i < numberOfObstacles; ++i)
        {
            obstacles.Add(new Antimatter());
        }
    }

    public void MakeObstacle()
    {
        obstacles.Add(new Antimatter());
    }

    public ExpeditionResult StartExpedition(IShip ship)
    {
        if (ship == null) throw new ArgumentException("Not initialized Spaceship");

        for (int i = 0; i < obstacles.Count; ++i)
        {
            if (ship.TakeAntimatterDamage() < 0) return new ExpeditionResult.TheCrewIsDead();
        }

        if (ship.CheckJumpEngineType() == null)
        {
            return new ExpeditionResult.LostSpaceship();
        }
        else
        {
            if (ship.UseJumpEngine(_distance))
            {
                ship.SetUsedFuel(ship.JumpedUsedFuel(_distance));

                return new ExpeditionResult.Success();
            }

            return new ExpeditionResult.LostSpaceship();
        }
    }

    public CompareResult CompareShips(IShip ship1, IShip ship2)
    {
        if (ship1 == null) throw new ArgumentException("Not initialized Spaceship");
        if (ship2 == null) throw new ArgumentException("Not initialized Spaceship");

        ExpeditionResult result1 = StartExpedition(ship1);
        ExpeditionResult result2 = StartExpedition(ship2);
        int usedFuel1;
        int usedFuel2;

        if (result1 == new ExpeditionResult.Success() && result2 == new ExpeditionResult.Success())
        {
            usedFuel1 = ship1.JumpedUsedFuel(_distance);
            usedFuel2 = ship2.JumpedUsedFuel(_distance);

            if (usedFuel1 < usedFuel2) return new CompareResult.FirstSpaceshipBetter();
            else return new CompareResult.SecondSpaceshipBetter();
        }
        else if (result1 != new ExpeditionResult.Success() && result2 != new ExpeditionResult.Success())
        {
            return new CompareResult.BothSpaceShipsUseless();
        }
        else if (result1 == new ExpeditionResult.Success())
        {
            return new CompareResult.FirstSpaceshipBetter();
        }
        else
        {
            return new CompareResult.SecondSpaceshipBetter();
        }
    }
}