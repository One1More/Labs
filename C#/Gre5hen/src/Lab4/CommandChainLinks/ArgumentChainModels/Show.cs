using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;
using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;

public class Show : ArgumentChainLinkBase
{
    private ShowMode _showMode;
    public Show()
    {
        _showMode = new ShowMode();
        Command = "show";
    }

    protected override string Command { get; }
    public override HandleResult SearchCommand(Request request)
    {
        if (request.CompareNext(Command))
        {
            FileShowContextBuilder builder = new FileShowContextBuilder().AddPath(request.Next());

            return _showMode.SearchCommand(request, builder);
        }
        else if (ChainLink is not null)
        {
            return ChainLink.SearchCommand(request);
        }

        return new HandleResult.Fail();
    }
}