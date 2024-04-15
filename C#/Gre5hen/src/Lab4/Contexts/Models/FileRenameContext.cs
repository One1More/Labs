namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class FileRenameContext
{
    public FileRenameContext(string path, string name)
    {
        Path = path;
        Name = name;
    }

    public string Path { get; }
    public string Name { get; }
}