package ru.gorbunov.app.contracts.user;

import ru.gorbunov.app.contracts.LoginResult;

public interface UserService {
    LoginResult tryLogin(String name, String surname);
    void makeClient(String name,
                    String Surname,
                    String address,
                    Integer passportNumber,
                    String bankName);
}
