using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;
using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.Models;

public class ConnectChain : CommandChainLinkBase
{
    private ConnectMode _mode;

    public ConnectChain()
    {
        KeyWord = "connect";
        _mode = new ConnectMode();
    }

    protected override string KeyWord { get; }
    public override HandleResult SearchCommand(Request key)
    {
        if (key.CompareNext(KeyWord))
        {
            ConnectContextBuilder builder = new ConnectContextBuilder().AddAddress(key.Next());

            return _mode.SearchCommand(key, builder);
        }
        else if (CommandChainLink is not null)
        {
            return CommandChainLink.SearchCommand(key);
        }

        return new HandleResult.Fail();
    }
}