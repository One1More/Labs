package ru.gorbunov.app.models.accounts;

import ru.gorbunov.app.contracts.bank.TopUpResult;
import ru.gorbunov.app.contracts.bank.WithdrawalResult;

public interface Account {
    int checkId();
    int checkMoney();
    boolean getVerifiatoion();
    void setVerification(boolean verification);
    AccountTypes checkType();
    WithdrawalResult withdraw(int money);
    TopUpResult topUp(int money);
    void doDailyAction();
}
