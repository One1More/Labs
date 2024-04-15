package ru.gorbunov.app.models;

import ru.gorbunov.app.models.clientBuilder.ClientBuilder;
import ru.gorbunov.app.models.clientBuilder.NameAddable;

public class Client implements User {
    private final Roles role;
    private final String name;
    private final String surname;
    private final String address;
    private final Integer passportNumber;
    private final String bankName;

    public static NameAddable Builder = new ClientBuilder();

    public Client(String name, String surname, String address, Integer passportNumber, String bankName) {
        this.name = name;
        this.surname = surname;
        this.address = address;
        this.passportNumber = passportNumber;
        this.bankName = bankName;
        role = Roles.CLIENT;
    }

    @Override
    public Roles getRole() {
        return role;
    }

    @Override
    public String getBankName() {
        return bankName;
    }

    @Override
    public boolean isVerified() {
        if (passportNumber != null || address != null) {
            return true;
        }

        return false;
    }

    public String getName() {
        return name;
    }

    public String getSurname() {
        return surname;
    }

    public void getNotification(String notification) {
        // some logic can be made
        return;
    }
}
