namespace Itmo.ObjectOrientedProgramming.Lab2.HardDisk;

public interface IHardDiskBuilder
{
    IHardDiskBuilder AddCapacity(int capacity);
    IHardDiskBuilder AddSpindleSpeed(int spindleSpeed);
    IHardDiskBuilder AddPowerConsumption(int powerConsumption);
    HardDisk Build();
}