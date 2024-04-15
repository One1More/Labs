namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;

public class MicroDIMM : IRamFormFactor
{
    public MicroDIMM(int id)
    {
        Id = id;
    }

    public int Id { get; }
}