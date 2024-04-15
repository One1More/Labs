using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.AdreseeBuilders;

public class MessageConverterBuilder : IBuilder
{
    private readonly ITextAdressee _adressee;
    private ILogger? _logger;
    private List<int>? _availableImportanceLevels;

    public MessageConverterBuilder(ITextAdressee adressee)
    {
        _adressee = adressee;
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

    public IAdressee Build()
    {
        if (_logger is not null && _availableImportanceLevels is not null)
        {
            var messangeConvertor = new MessangeConverter(_adressee);
            var withLog = new AdresseeWithLog(messangeConvertor, _logger);
            var withProxy = new ProxyAdressee(withLog, _availableImportanceLevels);

            return withProxy;
        }
        else if (_logger is not null)
        {
            var messangeConvertor = new MessangeConverter(_adressee);
            var withLog = new AdresseeWithLog(messangeConvertor, _logger);

            return withLog;
        }
        else if (_availableImportanceLevels is not null)
        {
            var messangeConvertor = new MessangeConverter(_adressee);
            var withProxy = new ProxyAdressee(messangeConvertor, _availableImportanceLevels);

            return withProxy;
        }
        else
        {
            var messangeConvertor = new MessangeConverter(_adressee);

            return messangeConvertor;
        }
    }
}