package ru.gorbunov.app.models.clientBuilder;

import ru.gorbunov.app.models.Client;

public class ClientBuilder implements NameAddable, SurnameAddable, AddBank , ClientBuilderAddable {
    private String name;
    private String surname;
    private String address;
    private Integer passportNumber;
    private String bank;

    @Override
    public ClientBuilderAddable addAddress(String address) {
        this.address = address;

        return this;
    }

    @Override
    public ClientBuilderAddable addPassport(Integer passport) {
        passportNumber = passport;

        return this;
    }

    @Override
    public Client build() {
        return new Client(name,
                surname,
                address,
                passportNumber,
                bank);
    }

    @Override
    public SurnameAddable addName(String name) {
        this.name = name;

        return this;
    }

    @Override
    public AddBank addSurname(String surname) {
        this.surname = surname;

        return this;
    }

    @Override
    public ClientBuilderAddable addBank(String bankName) {
        bank = bankName;

        return this;
    }
}
