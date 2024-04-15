using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public class PowerSupply : ICompatibility<IEnumerable<int>>
{
    public PowerSupply(int id, int peakLoad)
    {
        Id = id;
        PeakLoad = peakLoad;
    }

    public int Id { get; }
    public int PeakLoad { get; }
    public CompareResult Compare(IEnumerable<int> workWith)
    {
        int allPowerUsage = 0;

        foreach (int powerConsumption in workWith)
        {
            allPowerUsage += powerConsumption;
        }

        if (allPowerUsage > PeakLoad)
            return new CompareResult.Fail(nameof(PowerSupply), "Power usable components", "Peak Load is lower than usable.");
        else return new CompareResult.Success();
    }
}