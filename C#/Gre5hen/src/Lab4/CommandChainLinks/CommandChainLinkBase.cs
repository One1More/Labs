using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks;

public abstract class CommandChainLinkBase : ICommandChainLink
{
    protected ICommandChainLink? CommandChainLink { get; private set; }
    protected ArgumentChainLinkBase? ContextChainLink { get; set; }
    protected abstract string KeyWord { get; }
    public void AddNextCommand(ICommandChainLink chainLink)
    {
        if (CommandChainLink is null)
        {
            CommandChainLink = chainLink;
        }
        else
        {
            CommandChainLink.AddNextCommand(chainLink);
        }
    }

    public void AddNextContextChain(ArgumentChainLinkBase argumentChainLinkBase)
    {
        if (ContextChainLink is null)
        {
            ContextChainLink = argumentChainLinkBase;
        }
        else
        {
            ContextChainLink.AddNextContextChain(argumentChainLinkBase);
        }
    }

    public abstract HandleResult SearchCommand(Request key);
}