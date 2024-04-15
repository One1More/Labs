namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;

public class SODIMM : IRamFormFactor
{
    public SODIMM(int id)
    {
        Id = id;
    }

    public int Id { get; }
}