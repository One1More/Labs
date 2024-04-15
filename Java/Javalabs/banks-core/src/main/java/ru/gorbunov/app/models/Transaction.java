package ru.gorbunov.app.models;

import java.util.UUID;

public class Transaction {
    private final UUID id;
    private final int accountId;
    private final int money;
    private final TransactionType type;
    private final String bankName;

    public Transaction(int accountId, int money, TransactionType type, String bankName) {
        id = UUID.randomUUID();
        this.accountId = accountId;
        this.money = money;
        this.type = type;
        this.bankName = bankName;
    }

    public int getAccountId() {
        return accountId;
    }

    public int getMoney() {
        return money;
    }

    public TransactionType getType() {
        return type;
    }

    public String getBankName() {
        return bankName;
    }

    public UUID getId() {
        return id;
    }
}
