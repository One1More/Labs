package ru.gorbunov.app.models.accounts;

import ru.gorbunov.app.contracts.bank.TopUpResult;
import ru.gorbunov.app.contracts.bank.WithdrawalResult;

public class DebitAccount implements Account {
    private final int id;
    private int balance;
    private int balanceRemaining;
    private final AccountTypes type;
    private final int interestRate;
    private boolean verified;
    private final int maxUnverifiedAmount;
    public DebitAccount(int id, int interestRate) {
        this.id = id;
        this.interestRate = interestRate;
        type = AccountTypes.DEBIT;
        balance = 0;
        balanceRemaining = 0;
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
        if (balance - money < 0) {
            return new WithdrawalResult.InsufficientFunds();
        }

        if (!verified && money > maxUnverifiedAmount) {
            return new WithdrawalResult.NotVerified();
        }

        balance -= money;

        if (balanceRemaining > money) {
            balanceRemaining = money;
        }
        
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
        balanceRemaining += balance * interestRate / 365;
    }
}
