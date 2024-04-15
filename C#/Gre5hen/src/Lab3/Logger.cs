using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Logger : ILogger
{
    public void LogMessage(string message)
    {
        Console.WriteLine(message);
    }
}