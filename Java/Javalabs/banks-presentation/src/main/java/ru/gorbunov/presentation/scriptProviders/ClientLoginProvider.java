package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.contracts.user.UserService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.ClientLogin;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import java.util.Optional;

@Component
@Scope("prototype")
public class ClientLoginProvider implements ScriptProvider {
    private final CurrentUser user;
    private final UserService service;

    public ClientLoginProvider(CurrentUser user, UserService service) {
        this.user = user;
        this.service = service;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (user.user.isEmpty())
            return Optional.of(new ClientLogin(service));

        return Optional.empty();
    }
}
