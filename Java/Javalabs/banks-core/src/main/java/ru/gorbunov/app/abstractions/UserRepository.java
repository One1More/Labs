package ru.gorbunov.app.abstractions;

import ru.gorbunov.app.contracts.user.FindClientResult;
import ru.gorbunov.app.models.Client;

public interface UserRepository {
    FindClientResult findClient(String name, String surname);
    void addClient(Client client);
}
