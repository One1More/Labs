package ru.gorbunov.app.application.user;

import org.springframework.stereotype.Service;
import ru.gorbunov.app.abstractions.UserRepository;
import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.contracts.user.FindClientResult;
import ru.gorbunov.app.contracts.user.UserService;
import ru.gorbunov.app.models.Client;
import ru.gorbunov.app.models.CurrentUser;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Service
public class ClientServiceImpl implements UserService {
    private final UserRepository userRepository;
    private final CurrentUser currentUser;

    public ClientServiceImpl(UserRepository userRepository, CurrentUser currentUser) {
        this.userRepository = userRepository;
        this.currentUser = currentUser;
    }

    @Override
    public LoginResult tryLogin(String name, String surname) {
        var result = userRepository.findClient(name, surname);

        if (result instanceof FindClientResult.Success res)  {
            currentUser.user = Optional.of(res.user());

            return new LoginResult.Success();
        }

        return new LoginResult.Fail();
    }

    @Override
    public void makeClient(String name, String Surname, String address, Integer passportNumber, String bankName) {
        var client = Client.Builder
                .addName(name)
                .addSurname(Surname)
                .addBank(bankName)
                .addAddress(address)
                .addPassport(passportNumber)
                .build();

        userRepository.addClient(client);
    }
}
