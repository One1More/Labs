using Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.RAM;

public interface IRamBuilder
{
    IRamBuilder AddAvailableMemorySize(int size);
    IRamBuilder AddSupportedFrequency(int frequency);
    IRamBuilder AddAvailableXMPProfiles(int profile);
    IRamBuilder AddDDRVersion(float version);
    IRamBuilder AddFormFactor(IRamFormFactor formFactor);
    IRamBuilder AddPowerConsumption(int consumption);
    Ram Build();
}