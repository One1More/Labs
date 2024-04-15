using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree.TreeBuilder;

public interface ITreeBuilder
{
    IEnumerable<string> GetDirectories(string path);
    IEnumerable<string> GetFiles(string path);
}