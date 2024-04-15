using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Models;

public class EClassEngine : IEngine
{
    public int EngineFuelUsage(int distance)
    {
        int traveled = 0;
        int fuelunit = 1;

        while (traveled < distance)
        {
            traveled = (int)Math.Exp(fuelunit);

            fuelunit++;
        }

        int fuelconsumption = fuelunit * 4;

        return fuelconsumption;
    }
}