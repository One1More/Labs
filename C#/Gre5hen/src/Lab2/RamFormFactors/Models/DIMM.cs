namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;

public class DIMM : IRamFormFactor
{
    public DIMM(int id)
    {
        Id = id;
    }

    public int Id { get; }
}