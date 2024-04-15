package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.centralBank.CentralBankService;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class CreateNewBank implements Script {
    private final CentralBankService service;

    public CreateNewBank(CentralBankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Create new bank.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write bew bank   name:");
        String name = scanner.next();
        System.out.println("Write new bank interest rate:");
        int interestRate = scanner.nextInt();
        System.out.println("Write new bank percentage commission:");
        int commission = scanner.nextInt();

        if (interestRate < 0 || commission < 0) {
            System.out.println("You can't have negative rate or commission.");
        } else {
            service.createNewBank(name, interestRate, commission);
        }
    }
}

