namespace Itmo.ObjectOrientedProgramming.Lab2.FormFactor.Models;

public class MiniTower : IFormFactor
{
    public MiniTower(int id)
    {
        Id = id;
    }

    public int Id { get; }
}