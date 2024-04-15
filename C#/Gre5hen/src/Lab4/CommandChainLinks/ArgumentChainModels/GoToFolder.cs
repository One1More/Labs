using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;

public class GoToFolder : ArgumentChainLinkBase
{
    public GoToFolder()
    {
        Command = "goto";
    }

    protected override string Command { get; }
    public override HandleResult SearchCommand(Request request)
    {
        if (request.CompareNext(Command))
        {
            TreeGotoContext result = new TreeGotoContextBuilder()
                .AddPath(request.Next())
                .Build();

            return new HandleResult.Success(new TreeGoto(result));
        }
        else if (ChainLink is not null)
        {
            return ChainLink.SearchCommand(request);
        }

        return new HandleResult.Fail();
    }
}