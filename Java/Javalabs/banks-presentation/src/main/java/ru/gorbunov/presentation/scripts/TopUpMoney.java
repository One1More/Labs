package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.contracts.bank.TopUpResult;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class TopUpMoney implements Script {
    private final BankService service;

    public TopUpMoney(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Top up money.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write your account id?");
        int accountId = scanner.nextInt();
        System.out.println("How much money do you want to top up?");
        int money = scanner.nextInt();

        if (service.topUp(accountId, money) instanceof TopUpResult.Success) {
            System.out.println("Top up success.");
        } else if (service.topUp(accountId, money) instanceof TopUpResult.NotVerified) {
            System.out.println("Your account isn't verified.");
        } else {
            System.out.println("Couldn't find account.");
        }
    }
}
