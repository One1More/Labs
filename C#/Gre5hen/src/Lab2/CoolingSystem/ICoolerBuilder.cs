namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem;

public interface ICoolerBuilder
{
    ICoolerBuilder AddSocket(string socket);
    ICoolerBuilder AddTDP(int tdp);
    Cooler Build();
}