namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;

public interface ITreeComponent
{
    string Name { get; }
    void Accept(IVisitor visitor);
}