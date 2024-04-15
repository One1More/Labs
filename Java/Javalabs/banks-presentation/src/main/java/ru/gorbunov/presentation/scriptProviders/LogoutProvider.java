package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.Logout;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class LogoutProvider implements ScriptProvider {
    private final CurrentUser currentUser;

    public LogoutProvider(CurrentUser currentUser) {
        this.currentUser = currentUser;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isPresent())
            return Optional.of(new Logout(currentUser));

        return Optional.empty();
    }
}
