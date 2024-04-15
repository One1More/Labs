package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class CreateAccount implements Script {
    private final BankService service;

    public CreateAccount(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Create account";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Choose account type to create:");
        System.out.println("1.Debit.");
        System.out.println("2.Deposit.");
        System.out.println("3.Credit.");

        String answer = scanner.next();

        System.out.println("Write account id:");
        int accountId = scanner.nextInt();

        switch (answer) {
            case "1":
                service.createDebitAccount(accountId);
                break;
            case "2":
                service.createDepositAccount(accountId);
                break;
            case "3":
                service.createCreditAccount(accountId);
                break;
            default:
                System.out.println("You entered wrong number.");
                break;
        }
    }
}
