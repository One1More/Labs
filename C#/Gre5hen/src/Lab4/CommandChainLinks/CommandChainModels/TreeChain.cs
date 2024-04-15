using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.Models;

public class TreeChain : CommandChainLinkBase
{
    public TreeChain()
    {
        KeyWord = "tree";
        ContextChainLink = new List();
        ContextChainLink.AddNextContextChain(new GoToFolder());
    }

    protected override string KeyWord { get; }
    public override HandleResult SearchCommand(Request key)
    {
        if (key.CompareNext(KeyWord))
        {
            if (ContextChainLink is not null)
                return ContextChainLink.SearchCommand(key);
        }
        else if (CommandChainLink is not null)
        {
            return CommandChainLink.SearchCommand(key);
        }

        return new HandleResult.Fail();
    }
}