using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class FileShowContextBuilder
{
    private string _path;
    private string _mode;

    public FileShowContextBuilder()
    {
        _path = string.Empty;
        _mode = string.Empty;
    }

    public FileShowContextBuilder AddPath(string path)
    {
        _path = path;

        return this;
    }

    public FileShowContextBuilder AddMode(string mode)
    {
        _mode = mode;

        return this;
    }

    public FileShowContext Build()
    {
        return new FileShowContext(_path, _mode);
    }
}