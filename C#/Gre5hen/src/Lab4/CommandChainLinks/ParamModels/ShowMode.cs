using Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.Parser;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandChainLinks.ArgumentsModels;

public class ShowMode : IParamChain<FileShowContextBuilder>
{
    private IParamChain<FileShowContextBuilder>? _param;
    public ShowMode()
    {
        Flag = "-m";
    }

    public string Flag { get; }

    public HandleResult SearchCommand(Request request, FileShowContextBuilder builder)
    {
        if (request.CompareNext(Flag))
        {
            FileShowContext result = builder.AddMode(request.Next()).Build();

            return new HandleResult.Success(new FileShow(result));
        }
        else if (_param is not null)
        {
            return _param.SearchCommand(request, builder);
        }

        return new HandleResult.Fail();
    }

    public void AddNext(IParamChain<FileShowContextBuilder> param)
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