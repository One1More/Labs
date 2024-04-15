package ru.gorbunov.app.contracts.centralBank;

import ru.gorbunov.app.contracts.LoginResult;

public interface CentralBankService {
    LoginResult tryToLogIn(String someCode);
    void createNewBank(String name, int rate, int commission);
    TransferResult Transfer(int recepientId, String recepientBankName);
}
