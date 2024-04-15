namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Tree;

// чтобы не ругался на пустой интерфейс
#pragma warning disable CA1040
public interface IVisitor { }
#pragma warning restore CA1040

public interface IVisitor<T> : IVisitor
    where T : ITreeComponent
{
    void Visit(T component);
}