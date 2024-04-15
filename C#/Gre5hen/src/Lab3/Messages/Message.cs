using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Message : IRenderable
{
    public Message(string header, string body, int level)
    {
        Header = header;
        Body = body;
        Level = new ImportanceLevel(level);
    }

    public string Header { get; }
    public string Body { get; }
    public ImportanceLevel Level { get; }

    public void Render()
    {
        Console.WriteLine($"{Header}\n{Body}\n");
    }
}