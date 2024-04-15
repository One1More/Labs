package ru.gorbunov.app.models;

public class CentralBank implements User {
    @Override
    public Roles getRole() {
        return Roles.CENTRAL_BANK;
    }

    @Override
    public String getBankName() {
        return "Central bank";
    }

    @Override
    public boolean isVerified() {
        return true;
    }
}
