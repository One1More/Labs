package ru.gorbunov.presentation.scriptProviders;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Roles;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.SendNotification;
import java.util.Optional;

@Component
@Scope("prototype")
public class SendNotificationProvider implements ScriptProvider {
    private final BankService service;
    private final CurrentUser currentUser;

    public SendNotificationProvider(BankService service, CurrentUser currentUser) {
        this.service = service;
        this.currentUser = currentUser;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isPresent() && currentUser.user.get().getRole() == Roles.BANK) {
            return Optional.of(new SendNotification(service));
        }

        return Optional.empty();
    }
}
