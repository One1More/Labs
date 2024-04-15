package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.contracts.bank.TransactionCancelingResult;
import ru.gorbunov.app.models.TransactionType;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class CancelTransaction implements Script {
    private final BankService service;

    public CancelTransaction(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Cancel transaction.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Enter transaction id: ");
        var id = scanner.next();

        var result = service.cancelTransaction(id);

        if (result instanceof TransactionCancelingResult.Success) {
            System.out.println("Success");
        } else if (result instanceof TransactionCancelingResult.Fail) {
            System.out.println("Fail");
        }
    }
}
