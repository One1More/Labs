using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class TreeGoto : ICommand
{
    private readonly TreeGotoContext _context;

    public TreeGoto(TreeGotoContext context)
    {
        _context = context;
    }

    public OperationResult Execute(ref IFileSystem? fileSystem, ref string path)
    {
        if (fileSystem is not null)
        {
            return fileSystem.CanChangeFolder(_context.Path, ref path);
        }
        else
        {
            return new OperationResult.Fail();
        }
    }
}