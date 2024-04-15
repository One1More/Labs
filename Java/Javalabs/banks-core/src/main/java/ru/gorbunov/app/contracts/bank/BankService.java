package ru.gorbunov.app.contracts.bank;

import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.models.Transaction;
import ru.gorbunov.app.models.TransactionTransfer;

import java.util.List;

public interface BankService {

    LoginResult loginAsBank(String name);
    WithdrawalResult withdraw(int accountId, int money);
    TopUpResult topUp(int accountId, int money);
    void createDebitAccount(int accountId);
    void createDepositAccount(int accountId);
    void createCreditAccount(int accountId);
    TransferResult transfer(int accountId, int recipientId, String RecipientBankName, int money);
    void updateConditions(int interestRate, int commission);
    void scipTime(int days);
    int getBalance(int accountId);
    TransactionCancelingResult cancelTransaction(String id);
    List<TransactionTransfer> getBankTransactions();
    void addSubscriber();
    void sendNotifications(String notification);
}
