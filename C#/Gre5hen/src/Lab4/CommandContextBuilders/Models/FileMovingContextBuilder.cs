using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class FileMovingContextBuilder
{
    private string _sourcePath;
    private string _destinationPath;

    public FileMovingContextBuilder()
    {
        _sourcePath = string.Empty;
        _destinationPath = string.Empty;
    }

    public FileMovingContextBuilder AddSourcePath(string path)
    {
        _sourcePath = path;

        return this;
    }

    public FileMovingContextBuilder AddDestinationPath(string path)
    {
        _destinationPath = path;

        return this;
    }

    public FileMovingContext Build()
    {
        return new FileMovingContext(_sourcePath, _destinationPath);
    }
}