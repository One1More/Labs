package ru.gorbunov.dataAccess;

import ru.gorbunov.app.abstractions.UserRepository;
import ru.gorbunov.app.contracts.user.FindClientResult;
import ru.gorbunov.app.models.Client;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;

@Component
@Scope("singleton")
public class UserRepositoryImpl implements UserRepository {
    private List<Client> clients;

    public UserRepositoryImpl() {
        clients = new ArrayList<>();
    }

    @Override
    public FindClientResult findClient(String name, String surname) {
        for (Client client : clients) {
            if (client.getName().equals(name) && client.getSurname().equals(surname)) {
                return new FindClientResult.Success(client);
            }
        }

        return new FindClientResult.Fail();
    }

    @Override
    public void addClient(Client client) {
        clients.add(client);
    }
}
