namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface ICompatibility<T>
{
    CompareResult Compare(T workWith);
}