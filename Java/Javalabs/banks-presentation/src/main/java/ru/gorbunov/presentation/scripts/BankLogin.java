package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class BankLogin implements Script {
    private final BankService service;

    public BankLogin(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Login as bank.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write your Bank name:");
        String bankName = scanner.next();

        if (service.loginAsBank(bankName) instanceof LoginResult.Success) {
            System.out.println("Successful login.");
        } else {
            System.out.println("Couldn't find this bank.");
        }
    }
}
