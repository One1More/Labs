package ru.gorbunov.app.models;

import java.util.UUID;

public record TransactionTransfer(UUID id, int accountId, int money, TransactionType type) {
    public String toString() {
        return
            "id: " + id + ", " +
            "accountId: " + accountId + ", " +
            "money: " + money + ", " +
            "type: " + type;
    }
}
