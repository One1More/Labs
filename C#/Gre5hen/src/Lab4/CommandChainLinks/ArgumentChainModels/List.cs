using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;
using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;

public class List : ArgumentChainLinkBase
{
    private readonly Depth _param;

    public List()
    {
        Command = "list";
        _param = new Depth();
    }

    protected override string Command { get; }
    public override HandleResult SearchCommand(Request request)
    {
        if (request.CompareNext(Command))
        {
            var builder = new TreeListContextBuilder();

            return _param.SearchCommand(request, builder);
        }
        else if (ChainLink is not null)
        {
            return ChainLink.SearchCommand(request);
        }

        return new HandleResult.Fail();
    }
}