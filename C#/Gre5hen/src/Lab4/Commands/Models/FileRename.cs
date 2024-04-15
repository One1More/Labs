using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class FileRename : ICommand
{
    private readonly FileRenameContext _context;

    public FileRename(FileRenameContext context)
    {
        _context = context;
    }

    public OperationResult Execute(ref IFileSystem? fileSystem, ref string path)
    {
        if (fileSystem is not null)
        {
            return fileSystem.RenameFile(_context.Path, _context.Name, ref path);
        }
        else
        {
            return new OperationResult.Fail();
        }
    }
}