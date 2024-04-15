package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class UpdateConditions implements Script {
    private final BankService service;

    public UpdateConditions(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Update bank terms.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write bank new interest rate:");
        int interestRate = scanner.nextInt();
        System.out.println("Write bank new percentage commission:");
        int commission = scanner.nextInt();

        service.updateConditions(interestRate, commission);
    }
}
