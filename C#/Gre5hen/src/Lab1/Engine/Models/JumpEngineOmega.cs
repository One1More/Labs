using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;

public class JumpEngineOmega : IEngine, IJumpEngine
{
    public int EngineFuelUsage(int distance)
    {
        int fuelconsumption;
        int traveled;
        int fuelunit;

        traveled = 0;
        fuelunit = 1;

        while (traveled < distance)
        {
            traveled = (int)Math.Exp(fuelunit);

            fuelunit++;
        }

        fuelconsumption = fuelunit * 4;

        return fuelconsumption;
    }

    public bool CanPassNebulaeDistance(int distnace)
    {
        if (distnace < 1000)
            return true;
        else return false;
    }
}