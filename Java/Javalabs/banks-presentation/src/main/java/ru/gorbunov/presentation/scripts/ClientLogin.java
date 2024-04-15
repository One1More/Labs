package ru.gorbunov.presentation.scripts;

import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.contracts.user.UserService;
import ru.gorbunov.presentation.Script;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Scanner;

@Component
@Scope("prototype")
public class ClientLogin implements Script {
    private final UserService service;

    public ClientLogin(UserService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Login as client.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write your name:");
        String name = scanner.next();
        System.out.println("Write your surname:");
        String surname = scanner.next();

        if (service.tryLogin(name, surname) instanceof LoginResult.Success) {
            System.out.println("Successful login.");
        } else {
            System.out.println("Couldn't find this client.");
        }
    }
}
