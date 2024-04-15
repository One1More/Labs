using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.Models;

public class DisconnectChain : CommandChainLinkBase
{
    public DisconnectChain()
    {
        KeyWord = "disconnect";
    }

    protected override string KeyWord { get; }
    public override HandleResult SearchCommand(Request key)
    {
        if (key.CompareNext(KeyWord))
        {
            return new HandleResult.Success(new Disconnect());
        }
        else if (CommandChainLink is not null)
        {
            return CommandChainLink.SearchCommand(key);
        }

        return new HandleResult.Fail();
    }
}