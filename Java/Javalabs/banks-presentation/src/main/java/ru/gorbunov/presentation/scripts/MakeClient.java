package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.user.UserService;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class MakeClient implements Script {
    private final CurrentUser currentUser;
    private final UserService service;
    public MakeClient(CurrentUser currentUser, UserService service) {
        this.currentUser = currentUser;
        this.service = service;
    }

    @Override
    public String Name() {
        return "Make client";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write your name:");
        String name = scanner.next();
        System.out.println("Write your surname:");
        String surname = scanner.next();

        String address = null;
        Integer passportNumber = null;

        System.out.print("Write your address (write - to skip): ");
        String userAnswer = scanner.next();

        if (!userAnswer.equals("-")) {
            address = userAnswer;
        }

        System.out.print("Write your passport number (write - to skip): ");
        userAnswer = scanner.next();

        if (!userAnswer.equals("-")) {
            try {
                passportNumber = Integer.parseInt(userAnswer);
            } catch (NumberFormatException ignored) {
            }
        }

        service.makeClient(
                name,
                surname,
                address,
                passportNumber,
                currentUser.user.get().getBankName());
    }
}
