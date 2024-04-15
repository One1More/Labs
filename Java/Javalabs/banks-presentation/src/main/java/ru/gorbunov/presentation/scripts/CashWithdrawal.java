package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.contracts.bank.WithdrawalResult;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class CashWithdrawal implements Script {
    private final BankService service;

    public CashWithdrawal(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Withdraw money.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write your account id?");
        int accountId = scanner.nextInt();
        System.out.println("How much money do you want to withdraw?");
        int money = scanner.nextInt();

        WithdrawalResult result =service.withdraw(
                accountId,
                money);

        if (result instanceof WithdrawalResult.InsufficientFunds) {
            System.out.println("Insufficient funds.");
        } else if (result instanceof WithdrawalResult.Fail) {
            System.out.println("Can't find your account.");
        } else if (service.withdraw(accountId, money) instanceof WithdrawalResult.NotVerified) {
            System.out.println("Your account isn't verified.");
        }
    }
}
