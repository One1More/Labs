package ru.gorbunov.app.models.clientBuilder;

import ru.gorbunov.app.models.Client;

public interface ClientBuilderAddable {
    ClientBuilderAddable addAddress(String address);
    ClientBuilderAddable addPassport(Integer Passport);
    Client build();
}
