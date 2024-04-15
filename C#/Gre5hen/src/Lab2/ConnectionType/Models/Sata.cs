namespace Itmo.ObjectOrientedProgramming.Lab2.ConnectionType.Models;

public class Sata : IConnection
{
    public Sata(int id)
    {
        Id = id;
    }

    public int Id { get; }
}