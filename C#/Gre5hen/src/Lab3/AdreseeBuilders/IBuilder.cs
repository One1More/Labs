using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.AdreseeBuilders;

public interface IBuilder
{
    IBuilder WithProxy(IList<int> availableImportanceLevels);
    IBuilder WithLogger(ILogger logger);
    IAdressee Build();
}