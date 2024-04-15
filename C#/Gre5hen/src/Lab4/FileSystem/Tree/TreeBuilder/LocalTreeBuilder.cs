using System.Collections.Generic;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree.TreeBuilder;

public class LocalTreeBuilder : ITreeBuilder
{
    public IEnumerable<string> GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public IEnumerable<string> GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }
}