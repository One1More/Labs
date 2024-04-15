using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class FileMove : ICommand
{
    private readonly FileMovingContext _context;

    public FileMove(FileMovingContext context)
    {
        _context = context;
    }

    public OperationResult Execute(ref IFileSystem? fileSystem, ref string path)
    {
        if (fileSystem is not null)
        {
            return fileSystem.MoveFile(_context.SourcePath, _context.DestinationPath, ref path);
        }
        else
        {
            return new OperationResult.Fail();
        }
    }
}