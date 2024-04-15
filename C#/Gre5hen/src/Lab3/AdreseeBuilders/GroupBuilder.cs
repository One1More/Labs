using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.AdreseeBuilders;

public class GroupBuilder : IBuilder
{
    private List<IAdressee> _adressees;
    private ILogger? _logger;
    private List<int>? _availableImportanceLevels;

    public GroupBuilder()
    {
        _adressees = new List<IAdressee>();
    }

    public IBuilder WithProxy(IList<int> availableImportanceLevels)
    {
        _availableImportanceLevels = availableImportanceLevels.ToList();

        return this;
    }

    public IBuilder WithLogger(ILogger logger)
    {
        _logger = logger;

        return this;
    }

    public IBuilder AddAdressee(IAdressee adressee)
    {
        _adressees.Add(adressee);

        return this;
    }

    public IAdressee Build()
    {
        if (_logger is not null && _availableImportanceLevels is not null)
        {
            var group = new Group(_adressees);
            var withLog = new AdresseeWithLog(group, _logger);
            var withProxy = new ProxyAdressee(withLog, _availableImportanceLevels);

            return withProxy;
        }
        else if (_logger is not null)
        {
            var group = new Group(_adressees);
            var withLog = new AdresseeWithLog(group, _logger);

            return withLog;
        }
        else if (_availableImportanceLevels is not null)
        {
            var group = new Group(_adressees);
            var withProxy = new ProxyAdressee(group, _availableImportanceLevels);

            return withProxy;
        }
        else
        {
            var group = new Group(_adressees);

            return group;
        }
    }
}