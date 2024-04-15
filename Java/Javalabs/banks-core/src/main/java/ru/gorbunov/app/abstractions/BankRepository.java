package ru.gorbunov.app.abstractions;

import ru.gorbunov.app.contracts.bank.FindBankResult;
import ru.gorbunov.app.models.Bank;

public interface BankRepository {
    FindBankResult findBank(String name);
    void addBank(Bank bank);
}
