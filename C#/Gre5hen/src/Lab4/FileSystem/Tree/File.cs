namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;

public class File : ITreeComponent
{
    public File(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<File> v)
        {
            v.Visit(this);
        }
    }
}