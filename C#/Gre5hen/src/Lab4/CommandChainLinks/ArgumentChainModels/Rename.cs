using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;

public class Rename : ArgumentChainLinkBase
{
    public Rename()
    {
        Command = "rename";
    }

    protected override string Command { get; }
    public override HandleResult SearchCommand(Request request)
    {
        if (request.CompareNext(Command))
        {
            FileRenameContext result = new FileRenameContextBuilder().AddPath(request.Next()).Build();

            return new HandleResult.Success(new FileRename(result));
        }
        else if (ChainLink is not null)
        {
            return ChainLink.SearchCommand(request);
        }

        return new HandleResult.Fail();
    }
}