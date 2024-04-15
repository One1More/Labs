using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Models;

public class Disconnect : ICommand
{
    public OperationResult Execute(ref IFileSystem? fileSystem, ref string path)
    {
        fileSystem = null;

        return new OperationResult.Success();
    }
}