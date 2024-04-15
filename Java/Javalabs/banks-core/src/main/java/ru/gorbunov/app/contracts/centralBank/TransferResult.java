package ru.gorbunov.app.contracts.centralBank;

import ru.gorbunov.app.models.accounts.Account;

public interface TransferResult {
    record Success(Account account) implements TransferResult {}
    record Fail() implements TransferResult {}
    record WrongBankName() implements TransferResult {}
}
