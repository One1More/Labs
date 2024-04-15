using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class FileShowContext
{
    private string _mode;
    public FileShowContext(string path, string mode)
    {
        Path = path;
        _mode = mode;
    }

    public string Path { get; }

    public void ShowInfo(string info)
    {
        if (_mode == "console")
        {
            Console.WriteLine(info);
        }
    }
}