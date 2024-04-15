package ru.gorbunov.presentation.scripts;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.presentation.Script;
import java.util.ArrayList;
import java.util.List;

@Component
@Scope("prototype")
public class GetAllTransactions implements Script {
    private final BankService service;

    public GetAllTransactions(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Get all bank transactions";
    }

    @Override
    public void run() {
        List<String> transList = new ArrayList<>();

        var transactions = service.getBankTransactions();

        for (var transaction: transactions) {
            System.out.println(transaction.toString());
        }
    }
}
