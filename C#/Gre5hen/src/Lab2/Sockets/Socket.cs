namespace Itmo.ObjectOrientedProgramming.Lab2.Sockets;

public class Socket
{
    public Socket(string name, int id)
    {
        Name = name;
        Id = id;
    }

    public string Name { get; }
    public int Id { get; }
}