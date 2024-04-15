namespace Itmo.ObjectOrientedProgramming.Lab2.Chipset;

public interface IChipsetBuilder
{
    IChipsetBuilder AddPciLinesNumber(int number);
    IChipsetBuilder AddAvailableMemoryFrequencies(int frequency);
    IChipsetBuilder AddXMPSupply();
    Chipset Build();
}