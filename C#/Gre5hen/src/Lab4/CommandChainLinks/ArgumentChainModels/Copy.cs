using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;

public class Copy : ArgumentChainLinkBase
{
    public Copy()
    {
        Command = "copy";
    }

    protected override string Command { get; }
    public override HandleResult SearchCommand(Request request)
    {
        if (request.CompareNext(Command))
        {
            FileMovingContextBuilder builder = new FileMovingContextBuilder().AddSourcePath(request.Next());
            FileMovingContext result = builder.AddDestinationPath(request.Next()).Build();

            return new HandleResult.Success(new FileCopy(result));
        }
        else if (ChainLink is not null)
        {
            return ChainLink.SearchCommand(request);
        }

        return new HandleResult.Fail();
    }
}