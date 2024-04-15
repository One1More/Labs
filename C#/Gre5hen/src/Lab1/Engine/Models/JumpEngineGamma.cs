using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;

public class JumpEngineGamma : IEngine, IJumpEngine
{
    public int EngineFuelUsage(int distance)
    {
        int traveled = 0;
        int fuelunit = 1;

        while (traveled < distance)
        {
            traveled = (int)Math.Pow(3, fuelunit);

            fuelunit++;
        }

        int fuelconsumption = fuelunit * 6;

        return fuelconsumption;
    }

    public bool CanPassNebulaeDistance(int distnace)
    {
        return true;
    }
}