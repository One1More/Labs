using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presenation.Console;

public interface IScriptProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScript? script);
}