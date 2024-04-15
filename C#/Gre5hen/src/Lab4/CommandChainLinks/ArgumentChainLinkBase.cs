using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks;

public abstract class ArgumentChainLinkBase : IArgumentChainLink
{
    public ArgumentChainLinkBase? ChainLink { get; private set; }
    protected abstract string Command { get; }

    public void AddNextContextChain(ArgumentChainLinkBase argumentChainLinkBase)
    {
        if (ChainLink is null)
        {
            ChainLink = argumentChainLinkBase;
        }
        else
        {
            ChainLink.AddNextContextChain(argumentChainLinkBase);
        }
    }

    public abstract HandleResult SearchCommand(Request request);
}