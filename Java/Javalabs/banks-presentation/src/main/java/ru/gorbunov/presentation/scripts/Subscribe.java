package ru.gorbunov.presentation.scripts;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.presentation.Script;
import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.contracts.bank.FindBankResult;

@Component
@Scope("prototype")
public class Subscribe implements Script {
    private final BankService service;

    public Subscribe(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Subscribe on notification.";
    }

    @Override
    public void run() {
         service.addSubscriber();
    }
}
