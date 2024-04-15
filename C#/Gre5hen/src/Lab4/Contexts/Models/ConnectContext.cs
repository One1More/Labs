namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class ConnectContext
{
    public ConnectContext(string address, string mode)
    {
        Address = address;
        Mode = mode;
    }

    public string Address { get; }
    public string Mode { get; }
}