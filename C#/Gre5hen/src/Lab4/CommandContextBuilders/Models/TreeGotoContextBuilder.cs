using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class TreeGotoContextBuilder
{
    private string _path;

    public TreeGotoContextBuilder()
    {
        _path = string.Empty;
    }

    public TreeGotoContextBuilder AddPath(string path)
    {
        _path = path;

        return this;
    }

    public TreeGotoContext Build()
    {
        return new TreeGotoContext(_path);
    }
}