using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.AdreseeBuilders;

public class UserBuilder : IBuilder
{
    private ILogger? _logger;
    private List<int>? _availableImportanceLevels;

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

    public IAdressee Build()
    {
        if (_logger is not null && _availableImportanceLevels is not null)
        {
            var user = new User();
            var withLog = new AdresseeWithLog(user, _logger);
            var withProxy = new ProxyAdressee(withLog, _availableImportanceLevels);

            return withProxy;
        }
        else if (_logger is not null)
        {
            var user = new User();
            var withLog = new AdresseeWithLog(user, _logger);

            return withLog;
        }
        else if (_availableImportanceLevels is not null)
        {
            var user = new User();
            var withProxy = new ProxyAdressee(user, _availableImportanceLevels);

            return withProxy;
        }
        else
        {
            var user = new User();

            return user;
        }
    }
}