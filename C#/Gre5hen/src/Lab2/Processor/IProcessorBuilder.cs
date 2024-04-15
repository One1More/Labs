using Itmo.ObjectOrientedProgramming.Lab2.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Videocard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Processor;

public interface IProcessorBuilder
{
    IProcessorBuilder AddCoreFrequency(int frequency);
    IProcessorBuilder AddCoreNumber(int number);
    IProcessorBuilder AddSocket(Socket socket);
    IProcessorBuilder AddVideocard(VideoCard videoCard);
    IProcessorBuilder AddAvailableMemoryFrequencies(int frequency);
    IProcessorBuilder AddTdp(int tdp);
    IProcessorBuilder AddPowerConsumption(int consumption);
    Processor Build();
}