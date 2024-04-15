package ru.gorbunov.app.models.accounts;

import ru.gorbunov.app.contracts.bank.TopUpResult;
import ru.gorbunov.app.contracts.bank.WithdrawalResult;

public class DepositAccount implements Account {
    private final int id;
    private int balance;
    private final AccountTypes type;
    private final int interestRate;
    private boolean verified;
    private final int maxUnverifiedAmount;

    public DepositAccount(int id, int interestRate) {
        this.id = id;
        this.interestRate = interestRate;
        type = AccountTypes.DEPOSIT;
        balance = 0;
        maxUnverifiedAmount = 1000;
    }

    @Override
    public int checkId() {
        return id;
    }

    @Override
    public int checkMoney() {
        return balance;
    }
    @Override
    public boolean getVerifiatoion() {
        return verified;
    }

    @Override
    public void setVerification(boolean verification) {
        verified = verification;
    }

    @Override
    public AccountTypes checkType() {
        return type;
    }

    @Override
    public WithdrawalResult withdraw(int money) {
        return new WithdrawalResult.Fail();
    }

    @Override
    public TopUpResult topUp(int money) {
        if (!verified && money > maxUnverifiedAmount) {
            return new TopUpResult.NotVerified();
        }

        balance += money;

        return new TopUpResult.Success();
    }

    @Override
    public void doDailyAction() {
        balance += balance * interestRate / 365;
    }
}
