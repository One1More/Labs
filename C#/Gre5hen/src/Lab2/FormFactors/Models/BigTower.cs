namespace Itmo.ObjectOrientedProgramming.Lab2.FormFactor.Models;

public class BigTower : IFormFactor
{
    public BigTower(int id)
    {
        Id = id;
    }

    public int Id { get; }
}