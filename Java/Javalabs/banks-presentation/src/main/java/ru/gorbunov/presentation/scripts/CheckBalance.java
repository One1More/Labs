package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class CheckBalance implements Script {
    private final BankService service;

    public CheckBalance(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Check account balance";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Enter your account number: ");
        int accountNumber = scanner.nextInt();

        System.out.println("Your account balance is: " + service.getBalance(accountNumber));
    }
}
