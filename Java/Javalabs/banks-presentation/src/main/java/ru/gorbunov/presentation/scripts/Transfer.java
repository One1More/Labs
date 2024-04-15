package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.app.contracts.bank.TransferResult;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class Transfer implements Script {
    private final BankService service;

    public Transfer(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Transfer money to another account";
    }

    @Override
    public void run() {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Write your account id:");
        int id = scanner.nextInt();
        System.out.println("Write recipient bank name:");
        String bankName = scanner.next();
        System.out.println("Write recipient account id:");
        int recipientId = scanner.nextInt();

        System.out.println("Write amount of money you want to transfer");
        int money = scanner.nextInt();

        TransferResult result =service.transfer(
                id,
                recipientId,
                bankName,
                money);

        if (result instanceof TransferResult.WrongRecipientBankName) {
            System.out.println("Wrong recipient bank name");
        } else if (result instanceof TransferResult.WrongRecipientAccountId) {
            System.out.println("Wrong recipient account id");
        } else if (result instanceof TransferResult.WrongYourAccountId) {
            System.out.println("Wrong your account id");
        } else if (result instanceof TransferResult.InsufficientFunds) {
            System.out.println("Insufficient funds");
        } else if (result instanceof TransferResult.Fail) {
            System.out.println("Unknown error");
        } else {
            System.out.println("Success");
        }
    }
}
