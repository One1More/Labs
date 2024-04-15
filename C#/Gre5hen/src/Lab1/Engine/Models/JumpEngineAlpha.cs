using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;

public class JumpEngineAlpha : IEngine, IJumpEngine
{
    public int EngineFuelUsage(int distance)
    {
        int fuelconsumption;

        fuelconsumption = (int)Math.Ceiling(distance / 10.0f);

        return fuelconsumption;
    }

    public bool CanPassNebulaeDistance(int distnace)
    {
        if (distnace < 100)
            return true;
        else return false;
    }
}