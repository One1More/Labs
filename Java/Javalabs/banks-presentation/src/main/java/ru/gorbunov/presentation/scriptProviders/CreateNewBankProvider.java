package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.contracts.centralBank.CentralBankService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Roles;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.CreateNewBank;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class CreateNewBankProvider implements ScriptProvider {
    private final CurrentUser currentUser;
    private final CentralBankService service;

    public CreateNewBankProvider(CurrentUser currentUser, CentralBankService service) {
        this.currentUser = currentUser;
        this.service = service;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isPresent() && currentUser.user.get().getRole() == Roles.CENTRAL_BANK)
            return Optional.of(new CreateNewBank(service));

        return Optional.empty();
    }
}
