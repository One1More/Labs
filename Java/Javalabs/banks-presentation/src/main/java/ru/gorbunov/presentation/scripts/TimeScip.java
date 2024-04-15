package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class TimeScip implements Script {
    private final BankService service;

    public TimeScip(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Scip time.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("How many days do you want to scip?");
        int days = scanner.nextInt();

        service.scipTime(days);
    }
}
