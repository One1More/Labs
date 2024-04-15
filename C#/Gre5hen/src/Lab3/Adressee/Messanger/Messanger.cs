using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Messanger;

public class Messanger : ITextAdressee
{
    private string? Message { get; set; }

    public void TakeMessage(string message)
    {
        Message = message;
    }

    public void PrintMessage()
    {
        Console.WriteLine($"Messanger:\n{Message}\n");
    }
}