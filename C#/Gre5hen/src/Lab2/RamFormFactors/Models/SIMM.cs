namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;

public class SIMM : IRamFormFactor
{
    public SIMM(int id)
    {
        Id = id;
    }

    public int Id { get; }
}