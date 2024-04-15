namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfiles.Models;

public class XMPProfile : IXMPProfile
{
    public XMPProfile(int id, int timings, int voltage, int frequency)
    {
        Id = id;
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public int Id { get; }
    public int Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}