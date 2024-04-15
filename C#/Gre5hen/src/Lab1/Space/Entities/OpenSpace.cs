using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;

public class OpenSpace : ISpace
{
    private int _distance;
    private List<IObstacle> obstacles = new List<IObstacle>();

    public OpenSpace(int dist)
    {
        _distance = dist;
    }

    public OpenSpace(int dist, int asteroidNumber, int meteorNumber)
    {
        _distance = dist;

        for (int i = 0; i < asteroidNumber; ++i)
        {
            obstacles.Add(new Asteroid());
        }

        for (int i = 0; i < meteorNumber; ++i)
        {
            obstacles.Add(new Meteor());
        }
    }

    public void MakeObstacle()
    {
        obstacles.Add(new Asteroid());
    }

    public void MakeMeteorObstacle()
    {
        obstacles.Add(new Meteor());
    }

    public ExpeditionResult StartExpedition(IShip ship)
    {
        if (ship == null) throw new ArgumentException("Not initialized Spaceship");

        foreach (IObstacle obstacle in obstacles)
        {
            if (ship.TakeDeflectorDamage(obstacle) < 0)
                if (ship.TakeHullDamage(obstacle) < 0) return new ExpeditionResult.SpaceshipDistruction();
        }

        ship.SetUsedFuel(ship.UsedFuel(_distance));

        return new ExpeditionResult.Success();
    }

    public CompareResult CompareShips(IShip ship1, IShip ship2)
    {
        if (ship1 == null) throw new ArgumentException("Not initialized Spaceship");
        if (ship2 == null) throw new ArgumentException("Not initialized Spaceship");

        ExpeditionResult result1 = StartExpedition(ship1);
        ExpeditionResult result2 = StartExpedition(ship2);
        int usedFuel1 = ship1.UsedFuel(_distance);
        int usedFuel2 = ship2.UsedFuel(_distance);

        if (result1 == new ExpeditionResult.Success() && result2 == new ExpeditionResult.Success())
        {
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