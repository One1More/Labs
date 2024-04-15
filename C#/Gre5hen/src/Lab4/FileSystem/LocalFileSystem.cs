using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree.TreeBuilder;
using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(string path)
    {
        AbsolutePath = path;
    }

    public string AbsolutePath { get; private set; }

    public OperationResult CanChangeFolder(string path, ref string relativePath)
    {
        if (path.Contains(AbsolutePath, StringComparison.Ordinal))
        {
            if (Directory.Exists(path))
            {
                relativePath = path;

                return new OperationResult.Success();
            }
        }
        else if (Directory.Exists(Path.Combine(relativePath, path)))
        {
            relativePath = Path.Combine(relativePath, path);

            return new OperationResult.Success();
        }

        return new OperationResult.Fail();
    }

    public OperationResult ShowFile(string path, FileShowContext context, ref string relativePath)
    {
        if (path.Contains(AbsolutePath, StringComparison.Ordinal))
        {
            if (File.Exists(path))
            {
                context.ShowInfo(File.ReadAllText(path));

                return new OperationResult.Success();
            }
        }
        else
        {
            if (File.Exists(Path.Combine(relativePath, path)))
            {
                context.ShowInfo(File.ReadAllText(Path.Combine(relativePath, path)));

                return new OperationResult.Success();
            }
        }

        return new OperationResult.Fail();
    }

    public OperationResult CopyFile(string sourcePath, string destinationPath, ref string relativePath)
    {
        if (sourcePath.Contains(AbsolutePath, StringComparison.Ordinal))
        {
            if (File.Exists(sourcePath))
            {
                if (destinationPath.Contains(AbsolutePath, StringComparison.Ordinal))
                {
                    File.Copy(sourcePath, destinationPath, true);

                    return new OperationResult.Success();
                }
                else if (Directory.Exists(Path.Combine(relativePath, destinationPath)))
                {
                    File.Copy(sourcePath, Path.Combine(relativePath, destinationPath), true);

                    return new OperationResult.Success();
                }
            }
        }
        else
        {
            if (File.Exists(Path.Combine(relativePath, sourcePath)))
            {
                if (destinationPath.Contains(AbsolutePath, StringComparison.Ordinal))
                {
                    File.Copy(Path.Combine(relativePath, sourcePath), destinationPath, true);

                    return new OperationResult.Success();
                }
                else if (Directory.Exists(Path.Combine(relativePath, destinationPath)))
                {
                    File.Copy(Path.Combine(relativePath, sourcePath), Path.Combine(relativePath, destinationPath), true);

                    return new OperationResult.Success();
                }
            }
        }

        return new OperationResult.Fail();
    }

    public OperationResult MoveFile(string sourcePath, string destinationPath, ref string relativePath)
    {
        if (sourcePath.Contains(AbsolutePath, StringComparison.Ordinal))
        {
            if (File.Exists(sourcePath))
            {
                if (destinationPath.Contains(AbsolutePath, StringComparison.Ordinal))
                {
                    File.Move(sourcePath, destinationPath, true);

                    return new OperationResult.Success();
                }
                else if (Directory.Exists(Path.Combine(relativePath, destinationPath)))
                {
                    File.Move(sourcePath, Path.Combine(relativePath, destinationPath), true);

                    return new OperationResult.Success();
                }
            }
        }
        else
        {
            if (File.Exists(Path.Combine(relativePath, sourcePath)))
            {
                if (destinationPath.Contains(AbsolutePath, StringComparison.Ordinal))
                {
                    File.Copy(Path.Combine(relativePath, sourcePath), destinationPath, true);

                    return new OperationResult.Success();
                }
                else if (Directory.Exists(Path.Combine(relativePath, destinationPath)))
                {
                    File.Copy(Path.Combine(relativePath, sourcePath), Path.Combine(relativePath, destinationPath), true);

                    return new OperationResult.Success();
                }
            }
        }

        return new OperationResult.Fail();
    }

    public OperationResult DeleteFile(string path, ref string relativePath)
    {
        if (path.Contains(AbsolutePath, StringComparison.Ordinal))
        {
            if (File.Exists(path))
            {
                File.Delete(path);

                return new OperationResult.Success();
            }
        }
        else
        {
            if (File.Exists(Path.Combine(relativePath, path)))
            {
                File.Delete(Path.Combine(relativePath, path));

                return new OperationResult.Success();
            }
        }

        return new OperationResult.Fail();
    }

    public OperationResult RenameFile(string path, string name, ref string relativePath)
    {
        if (path.Contains(AbsolutePath, StringComparison.Ordinal))
        {
            if (File.Exists(path))
            {
                string directory = Path.GetDirectoryName(path) ?? string.Empty;
                string newPath = Path.Combine(directory, name);

                File.Move(path, newPath, true);

                return new OperationResult.Success();
            }
        }
        else if (File.Exists(Path.Combine(Path.Combine(relativePath, path))))
        {
            string directory = Path.GetDirectoryName(Path.Combine(relativePath, path)) ?? string.Empty;
            string newPath = Path.Combine(directory, name);

            File.Move(Path.Combine(relativePath, path), newPath, true);

            return new OperationResult.Success();
        }

        return new OperationResult.Fail();
    }

    public Folder WriteTree(int depth, ref string relativePath)
    {
        var folder = new Folder(relativePath);
        folder.AddAllDirectorys(
            depth,
            1,
            relativePath,
            new LocalTreeBuilder());

        return folder;
    }
}