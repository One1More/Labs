namespace Lab5.Presenation.Console.Scenarios.ExitApp;

public class ExitScript : IScript
{
    public string Name => "Exit";
    public void Run()
    {
        Environment.Exit(0);
    }
}