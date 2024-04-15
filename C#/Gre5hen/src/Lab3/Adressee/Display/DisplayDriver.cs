using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Display;

public class DisplayDriver : IDisplayDriver
{
    public void CleanOutput()
    {
        Console.Clear();
    }

    public void PrintMessage(string info)
    {
        Console.WriteLine(info + '\n');
    }
}