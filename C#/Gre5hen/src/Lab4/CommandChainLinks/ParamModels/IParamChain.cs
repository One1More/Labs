using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;

public interface IParamChain<T>
{
    HandleResult SearchCommand(Request request, T builder);
    void AddNext(IParamChain<T> param);
}