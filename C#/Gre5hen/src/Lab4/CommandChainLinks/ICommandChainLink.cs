using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks;

public interface ICommandChainLink
{
    void AddNextCommand(ICommandChainLink chainLink);
    void AddNextContextChain(ArgumentChainLinkBase argumentChainLinkBase);
    HandleResult SearchCommand(Request key);
}