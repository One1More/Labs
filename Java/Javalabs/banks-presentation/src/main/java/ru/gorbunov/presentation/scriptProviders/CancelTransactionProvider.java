package ru.gorbunov.presentation.scriptProviders;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Roles;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.presentation.ScriptProvider;
import ru.gorbunov.presentation.scripts.CancelTransaction;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("prototype")
public class CancelTransactionProvider implements ScriptProvider {
    private final CurrentUser currentUser;
    private final BankService bankService;

    public CancelTransactionProvider(CurrentUser currentUser, BankService bankService) {
        this.currentUser = currentUser;
        this.bankService = bankService;
    }


    @Override
    public Optional<Script> tryGetScenario() {
        if (currentUser.user.isPresent() && currentUser.user.get().getRole() == Roles.BANK) {
            return Optional.of(new CancelTransaction(bankService));
        }

        return Optional.empty();
    }
}
