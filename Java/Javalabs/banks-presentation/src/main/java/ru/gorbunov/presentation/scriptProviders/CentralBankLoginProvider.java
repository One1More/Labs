package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.contracts.centralBank.CentralBankService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.CentralBankLogin;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class CentralBankLoginProvider implements ScriptProvider {
    private final CurrentUser currentUser;
    private final CentralBankService service;

    public CentralBankLoginProvider(CurrentUser currentUser, CentralBankService service) {
        this.currentUser = currentUser;
        this.service = service;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isEmpty())
            return Optional.of(new CentralBankLogin(service));


        return Optional.empty();
    }
}
