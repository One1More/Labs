package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.Exit;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class ExitProvider implements ScriptProvider {
    @Override
    public Optional<Script> tryGetScenario() {
        return Optional.of(new Exit());
    }
}
