package ru.gorbunov.app.abstractions;

import ru.gorbunov.app.models.Transaction;
import ru.gorbunov.app.models.TransactionType;

import java.util.List;
import java.util.Optional;

public interface TransactionsRepository {
    void addTransaction(Transaction transaction);
    List<Transaction> getTransactions(String bankName);
    Optional<Transaction> findTransaction(String id);
}
