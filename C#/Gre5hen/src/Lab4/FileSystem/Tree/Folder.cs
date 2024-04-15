using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree.TreeBuilder;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;

public class Folder : ITreeComponent
{
    public Folder(string name)
    {
        Name = name;
        Folders = new List<Folder>();
        Files = new List<File>();
    }

    public string Name { get; }

    public IList<Folder> Folders { get; }
    public IList<File> Files { get; }

    public void AddAllDirectorys(int depth, int currentDepth, string path, ITreeBuilder builder)
    {
        if (currentDepth <= depth)
        {
            IEnumerable<string> folders = builder.GetDirectories(path);
            foreach (string folder in folders)
            {
                Folders.Add(new Folder(folder));
                Folders.Last().AddAllDirectorys(
                    depth,
                    currentDepth + 1,
                    Folders.Last().Name,
                    builder);
            }

            IEnumerable<string> files = builder.GetFiles(path);
            foreach (string file in files)
            {
                Files.Add(new File(file));
            }
        }
    }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<Folder> v)
        {
            v.Visit(this);
        }
    }
}