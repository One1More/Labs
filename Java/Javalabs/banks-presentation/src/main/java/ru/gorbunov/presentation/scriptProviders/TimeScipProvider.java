package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Roles;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.TimeScip;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class TimeScipProvider implements ScriptProvider {
    private final CurrentUser currentUser;
    private final BankService service;

    public TimeScipProvider(CurrentUser currentUser, BankService service) {
        this.currentUser = currentUser;
        this.service = service;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isPresent() && currentUser.user.get().getRole() == Roles.BANK) {
            return Optional.of(new TimeScip(service));
        }

        return Optional.empty();
    }
}
