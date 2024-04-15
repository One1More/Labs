namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;

public class FBDIMM : IRamFormFactor
{
    public FBDIMM(int id)
    {
        Id = id;
    }

    public int Id { get; }
}