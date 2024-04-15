using Spectre.Console;

namespace Lab5.Presenation.Console;

public class ScriptRunner
{
    private readonly IEnumerable<IScriptProvider> _scriptProviders;

    public ScriptRunner(IEnumerable<IScriptProvider> scriptProviders)
    {
        _scriptProviders = scriptProviders;
    }

    public void Run()
    {
        IEnumerable<IScript> scripts = GetScripts();

        SelectionPrompt<IScript> actions = new SelectionPrompt<IScript>()
            .Title("Select action:")
            .AddChoices(scripts)
            .UseConverter(x => x.Name);

        IScript script = AnsiConsole.Prompt(actions);
        script.Run();
    }

    private IEnumerable<IScript> GetScripts()
    {
        foreach (IScriptProvider scriptProvider in _scriptProviders)
        {
            if (scriptProvider.TryGetScenario(out IScript? script))
                yield return script;
        }
    }
}