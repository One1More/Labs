using Itmo.ObjectOrientedProgramming.Lab2.ConnectionType;

namespace Itmo.ObjectOrientedProgramming.Lab2.SSD;

public interface ISSDBuilder
{
    ISSDBuilder AddConnectionType(IConnection type);
    ISSDBuilder AddCapacity(int capacity);
    ISSDBuilder AddMaxWorkSpeed(int speed);
    ISSDBuilder AddPowerConsumption(int consumption);
    SSD Build();
}