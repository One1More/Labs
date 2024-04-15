using Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandContextBuilders.Models;

public class ConnectContextBuilder
{
    private string _address;
    private string _mode;

    public ConnectContextBuilder()
    {
        _address = string.Empty;
        _mode = string.Empty;
    }

    public ConnectContextBuilder AddAddress(string addresse)
    {
        _address = addresse;

        return this;
    }

    public ConnectContextBuilder AddMode(string mode)
    {
        _mode = mode;

        return this;
    }

    public ConnectContext Build()
    {
        return new ConnectContext(_address, _mode);
    }
}