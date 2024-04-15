package ru.gorbunov.dataAccess;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.app.abstractions.TransactionsRepository;
import ru.gorbunov.app.models.Transaction;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.UUID;

@Component
@Scope("singleton")
public class TransactionsRepositoryImpl implements TransactionsRepository {
    private List<Transaction> transactions;

    public TransactionsRepositoryImpl() {
        transactions = new ArrayList<>();
    }

    public void addTransaction(Transaction transaction) {
        transactions.add(transaction);
    }

    @Override
    public List<Transaction> getTransactions(String bankName) {
        List<Transaction> transactionList = new ArrayList<>();

        for (var transaction: transactions) {
            if (transaction.getBankName().equals(bankName)) {
                transactions.add(transaction);
            }
        }

        return transactionList;
    }

    public Optional<Transaction> findTransaction(String id) {
        for (var transaction : transactions) {
            if (transaction.getId() == UUID.fromString(id)) {

                return Optional.of(transaction);
            }
        }

        return Optional.empty();
    }
}
