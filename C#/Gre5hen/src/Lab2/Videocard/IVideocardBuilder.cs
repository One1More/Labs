namespace Itmo.ObjectOrientedProgramming.Lab2.Videocard;

public interface IVideocardBuilder
{
    IVideocardBuilder AddLength(int length);
    IVideocardBuilder AddWidth(int width);
    IVideocardBuilder AddPciVersion(float version);
    IVideocardBuilder AddChipFrequency(int frequency);
    IVideocardBuilder AddPowerConsumption(int powerConsumption);
    VideoCard Build();
}