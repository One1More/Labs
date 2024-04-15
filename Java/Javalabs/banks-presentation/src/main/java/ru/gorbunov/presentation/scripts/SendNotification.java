package ru.gorbunov.presentation.scripts;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.app.contracts.bank.BankService;
import ru.gorbunov.presentation.Script;
import java.util.Scanner;

@Component
@Scope("prototype")
public class SendNotification implements Script {
    private final BankService service;

    public SendNotification(BankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Send notifications to all subscribers";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Enter message: ");
        String message = scanner.nextLine();

        service.sendNotifications(message);
    }
}
