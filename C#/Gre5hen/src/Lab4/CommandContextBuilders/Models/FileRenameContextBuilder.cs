using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class FileRenameContextBuilder
{
    private string _path;
    private string _name;

    public FileRenameContextBuilder()
    {
        _path = string.Empty;
        _name = string.Empty;
    }

    public FileRenameContextBuilder AddPath(string path)
    {
        _path = path;

        return this;
    }

    public FileRenameContextBuilder AddName(string name)
    {
        _name = name;

        return this;
    }

    public FileRenameContext Build()
    {
        return new FileRenameContext(_path, _name);
    }
}