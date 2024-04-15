using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks;

public interface IArgumentChainLink
{
    void AddNextContextChain(ArgumentChainLinkBase argumentChainLinkBase);
    HandleResult SearchCommand(Request request);
}