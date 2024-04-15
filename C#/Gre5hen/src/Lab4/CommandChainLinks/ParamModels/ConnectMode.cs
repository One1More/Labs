using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;

public class ConnectMode : IParamChain<ConnectContextBuilder>
{
    private IParamChain<ConnectContextBuilder>? _param;
    public ConnectMode()
    {
        Flag = "-m";
    }

    public string Flag { get; }

    public HandleResult SearchCommand(Request request, ConnectContextBuilder builder)
    {
        if (request.CompareNext(Flag))
        {
            ConnectContext result = builder.AddMode(request.Next()).Build();

            return new HandleResult.Success(new Connect(result));
        }
        else if (_param is not null)
        {
            return _param.SearchCommand(request, builder);
        }

        return new HandleResult.Fail();
    }

    public void AddNext(IParamChain<ConnectContextBuilder> param)
    {
        if (_param is null)
        {
            _param = param;
        }
        else
        {
            param.AddNext(param);
        }
    }
}