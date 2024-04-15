using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks;
using Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.Models;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class Parser
{
    private CommandChainLinkBase _chain;

    public Parser()
    {
        _chain = new ConnectChain();
        _chain.AddNextCommand(new TreeChain());
        _chain.AddNextCommand(new FileChain());
        _chain.AddNextCommand(new DisconnectChain());
    }

    public HandleResult Parse(string command)
    {
        var request = new Request(command);

        return _chain.SearchCommand(request);
    }
}