package ru.gorbunov.app.models;

public interface User {
    Roles getRole();
    String getBankName();

    boolean isVerified();
}
