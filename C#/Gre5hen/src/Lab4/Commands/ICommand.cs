using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    OperationResult Execute(ref IFileSystem? fileSystem, ref string path);
}