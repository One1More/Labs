using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;

public class Group : IAdressee
{
    private readonly IEnumerable<IAdressee> _adressees;

    public Group(IEnumerable<IAdressee> adressees)
    {
        _adressees = adressees;
    }

    public void TakeMessage(Message message)
    {
        foreach (IAdressee adressee in _adressees)
        {
            adressee.TakeMessage(message);
        }
    }
}