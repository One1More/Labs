using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Spaceships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Entities;

public interface ISpace
{
    void MakeObstacle();

    ExpeditionResult StartExpedition(IShip ship);
    CompareResult CompareShips(IShip ship1, IShip ship2);
}