namespace Itmo.ObjectOrientedProgramming.Lab2.XMPProfiles;

public interface IXMPProfile
{
    int Id { get; }
    int Timings { get; }
    int Voltage { get; }
    int Frequency { get; }
}