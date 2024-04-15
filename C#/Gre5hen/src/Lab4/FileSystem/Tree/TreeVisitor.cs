using System;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;

public class TreeVisitor : IVisitor<Folder>, IVisitor<File>
{
    private int _depth;

    public TreeVisitor()
    {
        _depth = 0;
    }

    public void Visit(Folder component)
    {
        string str = string.Concat(Enumerable.Repeat('\t', _depth));
        Console.WriteLine(str + Path.GetFileName(component.Name));

        _depth += 1;

        foreach (Folder folder in component.Folders)
        {
            folder.Accept(this);
        }

        foreach (File file in component.Files)
        {
            file.Accept(this);
        }

        _depth -= 1;
    }

    public void Visit(File component)
    {
        string str = string.Concat(Enumerable.Repeat('\t', _depth));
        Console.WriteLine(str + Path.GetFileName(component.Name));
    }
}