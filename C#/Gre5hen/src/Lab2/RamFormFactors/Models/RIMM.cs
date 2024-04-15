namespace Itmo.ObjectOrientedProgramming.Lab2.RamFormFactors.Models;

public class RIMM : IRamFormFactor
{
    public RIMM(int id)
    {
        Id = id;
    }

    public int Id { get; }
}