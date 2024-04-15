using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Display;

public class ModifiedDisplayDriver : IDisplayDriver
{
    private readonly Color _colour;
    private readonly IDisplayDriver _displayDriver;

    public ModifiedDisplayDriver(IDisplayDriver driver, Color colour)
    {
        _displayDriver = driver;
        _colour = colour;
    }

    public void CleanOutput()
    {
        Console.Clear();
    }

    public void PrintMessage(string info)
    {
        _displayDriver.PrintMessage(Crayon.Output.Rgb(_colour.R, _colour.G, _colour.B).Text(info));
    }
}