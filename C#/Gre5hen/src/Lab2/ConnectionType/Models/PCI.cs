namespace Itmo.ObjectOrientedProgramming.Lab2.ConnectionType.Models;

public class PCI : IConnection
{
    public PCI(int id)
    {
        Id = id;
    }

    public int Id { get; }
}