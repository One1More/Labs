namespace Itmo.ObjectOrientedProgramming.Lab3;

public abstract record MessageReadStatus
{
    private MessageReadStatus() { }

    public sealed record MessageRead : MessageReadStatus;

    public sealed record MessageIsNotRead : MessageReadStatus;
}