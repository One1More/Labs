package ru.gorbunov.app.models.accounts;

import ru.gorbunov.app.contracts.bank.TopUpResult;
import ru.gorbunov.app.contracts.bank.WithdrawalResult;

public class CreditAccount implements Account {
    private final int id;
    private int balance;
    private final AccountTypes type;
    private final int percentageCommission;
    private boolean verified;
    private final int maxUnverifiedAmount;

    public CreditAccount(int id, int percentageCommission) {
        this.id = id;
        this.percentageCommission = percentageCommission;
        type = AccountTypes.CREDIT;
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
    public AccountTypes checkType() {
        return type;
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
    public WithdrawalResult withdraw(int money) {
        if (!verified && money > maxUnverifiedAmount) {
            return new WithdrawalResult.NotVerified();
        }

        balance -= money;

        return new WithdrawalResult.Success();
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
        if (balance < 0) {
            balance -= percentageCommission * balance / 100;
        }
    }
}
