namespace Itmo.ObjectOrientedProgramming.Lab2.FormFactor.Models;

public class MidiTower : IFormFactor
{
    public MidiTower(int id)
    {
        Id = id;
    }

    public int Id { get; }
}