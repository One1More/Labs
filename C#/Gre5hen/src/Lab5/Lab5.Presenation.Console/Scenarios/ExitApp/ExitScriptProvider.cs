using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presenation.Console.Scenarios.ExitApp;

public class ExitScriptProvider : IScriptProvider
{
    public bool TryGetScenario([NotNullWhen(true)] out IScript? script)
    {
        script = new ExitScript();

        return true;
    }
}