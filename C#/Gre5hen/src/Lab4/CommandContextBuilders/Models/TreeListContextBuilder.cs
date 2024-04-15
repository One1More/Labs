using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class TreeListContextBuilder
{
    private string? _depth;

    public TreeListContextBuilder AddDepth(string? depth)
    {
        _depth = depth;

        return this;
    }

    public TreeListContext Build()
    {
        return new TreeListContext(_depth ?? "1");
    }
}