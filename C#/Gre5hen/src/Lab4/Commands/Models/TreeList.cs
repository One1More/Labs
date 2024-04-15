using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class TreeList : ICommand
{
    private readonly TreeListContext _context;

    public TreeList(TreeListContext context)
    {
        _context = context;
    }

    public OperationResult Execute(ref IFileSystem? fileSystem, ref string path)
    {
        if (fileSystem is not null)
        {
            Folder folder = fileSystem.WriteTree(_context.Depth, ref path);
            var visitor = new TreeVisitor();

            folder.Accept(visitor);

            return new OperationResult.Success();
        }
        else
        {
            return new OperationResult.Fail();
        }
    }
}