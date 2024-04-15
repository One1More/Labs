package ru.gorbunov.presentation.scripts;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.contracts.centralBank.CentralBankService;
import ru.gorbunov.presentation.Script;

import java.util.Scanner;

@Component
@Scope("prototype")
public class CentralBankLogin implements Script {
    private final CentralBankService service;

    public CentralBankLogin(CentralBankService service) {
        this.service = service;
    }

    @Override
    public String Name() {
        return "Login as central bank.";
    }

    @Override
    public void run() {
        var scanner = new Scanner(System.in);

        System.out.println("Write \"Central bank\" to login:");
        String name = scanner.nextLine();

        if (service.tryToLogIn(name) instanceof LoginResult.Success) {
            System.out.println("Successful login.");
        } else {
            System.out.println("Wrong code name.");
        }
    }
}
