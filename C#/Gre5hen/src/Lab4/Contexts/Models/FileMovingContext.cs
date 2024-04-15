namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class FileMovingContext
{
    public FileMovingContext(string sourcePath, string destinationPath)
    {
        SourcePath = sourcePath;
        DestinationPath = destinationPath;
    }

    public string SourcePath { get; }
    public string DestinationPath { get; }
}