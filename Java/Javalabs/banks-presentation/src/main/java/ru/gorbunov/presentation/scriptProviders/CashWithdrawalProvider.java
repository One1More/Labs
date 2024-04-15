package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Roles;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.CashWithdrawal;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class CashWithdrawalProvider implements ScriptProvider {
    private final CurrentUser currentUser;
    private final BankService service;

    public CashWithdrawalProvider(CurrentUser currentUser, BankService service) {
        this.currentUser = currentUser;
        this.service = service;
    }

    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isPresent() && currentUser.user.get().getRole() == Roles.CLIENT)
            return Optional.of(new CashWithdrawal(service));

        return Optional.empty();
    }
}
