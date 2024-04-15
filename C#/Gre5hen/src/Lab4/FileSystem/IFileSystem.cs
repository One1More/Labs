using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public interface IFileSystem
{
    OperationResult CanChangeFolder(string path, ref string relativePath);
    OperationResult ShowFile(string path, FileShowContext context, ref string relativePath);
    OperationResult CopyFile(string sourcePath, string destinationPath, ref string relativePath);
    OperationResult MoveFile(string sourcePath, string destinationPath, ref string relativePath);
    OperationResult DeleteFile(string path, ref string relativePath);
    OperationResult RenameFile(string path, string name, ref string relativePath);
    Folder WriteTree(int depth, ref string relativePath);
}