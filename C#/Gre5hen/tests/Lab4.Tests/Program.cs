namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public static class Program
{
    public static void Func()
    {
        var parser = new Parser.Parser();
        var commander = new Commander.Commander();

        commander.RunCommand(parser.Parse("connect C:\\test -m local"));
        commander.RunCommand(parser.Parse("tree list -d 3"));
        commander.RunCommand(parser.Parse("file copy C:\\test\\text_.txt C:\\test\\Lab2\\text.txt"));
        commander.RunCommand(parser.Parse("tree goto Lab2"));
        commander.RunCommand(parser.Parse("file show text.txt -m console"));
        commander.RunCommand(parser.Parse("file delete text.txt"));
        commander.RunCommand(parser.Parse("disconnect"));
    }
}