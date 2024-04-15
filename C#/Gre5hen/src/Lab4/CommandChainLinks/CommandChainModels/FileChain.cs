using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentChainModels;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.Models;

public class FileChain : CommandChainLinkBase
{
    public FileChain()
    {
        KeyWord = "file";
        ContextChainLink = new Copy();
        ContextChainLink.AddNextContextChain(new Move());
        ContextChainLink.AddNextContextChain(new Delete());
        ContextChainLink.AddNextContextChain(new Rename());
        ContextChainLink.AddNextContextChain(new Show());
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