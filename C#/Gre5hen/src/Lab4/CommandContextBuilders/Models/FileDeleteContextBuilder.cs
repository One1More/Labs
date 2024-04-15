using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class FileDeleteContextBuilder
{
    private string _path;

    public FileDeleteContextBuilder()
    {
        _path = string.Empty;
    }

    public FileDeleteContextBuilder AddPath(string path)
    {
        _path = path;

        return this;
    }

    public FileDeleteContext Build()
    {
        return new FileDeleteContext(_path);
    }
}