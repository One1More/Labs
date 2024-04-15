using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;

public class ProxyAdressee : IAdressee
{
    private readonly IAdressee _adressee;
    private readonly List<int> _availableImportanceLevels;

    public ProxyAdressee(IAdressee adressee, IList<int> availableImportanceLevels)
    {
        _adressee = adressee;
        _availableImportanceLevels = availableImportanceLevels.ToList();
    }

    public void TakeMessage(Message message)
    {
        if (_availableImportanceLevels.Contains(message.Level.Level))
            _adressee.TakeMessage(message);
    }
}