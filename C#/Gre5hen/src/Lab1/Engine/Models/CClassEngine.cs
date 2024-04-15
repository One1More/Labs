using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;

public class CClassEngine : IEngine
{
    public int EngineFuelUsage(int distance)
    {
        int fuelconsumption = (int)Math.Ceiling(distance / 10.0f);

        return fuelconsumption;
    }
}