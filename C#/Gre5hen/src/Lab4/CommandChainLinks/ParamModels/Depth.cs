using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;

public class Depth : IParamChain<TreeListContextBuilder>
{
    private IParamChain<TreeListContextBuilder>? _param;
    public Depth()
    {
        Flag = "-d";
    }

    public string Flag { get; }

    public HandleResult SearchCommand(Request request, TreeListContextBuilder builder)
    {
        if (request.CompareNext(Flag))
        {
            TreeListContext result = builder.AddDepth(request.Next()).Build();

            return new HandleResult.Success(new TreeList(result));
        }
        else if (string.IsNullOrEmpty(request.Next()))
        {
            TreeListContext result = builder.Build();

            return new HandleResult.Success(new TreeList(result));
        }
        else if (_param is not null)
        {
            return _param.SearchCommand(request, builder);
        }

        return new HandleResult.Fail();
    }

    public void AddNext(IParamChain<TreeListContextBuilder> param)
    {
        if (_param is null)
        {
            _param = param;
        }
        else
        {
            param.AddNext(param);
        }
    }
}