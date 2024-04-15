package ru.gorbunov.app.contracts.bank;

import ru.gorbunov.app.models.Bank;

public interface FindBankResult {
    public final record Success(Bank bank) implements FindBankResult {}
    public final record Fail() implements FindBankResult {}
}
