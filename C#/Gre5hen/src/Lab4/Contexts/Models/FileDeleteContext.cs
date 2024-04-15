namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class FileDeleteContext
{
    public FileDeleteContext(string path)
    {
        Path = path;
    }

    public string Path { get; }
}