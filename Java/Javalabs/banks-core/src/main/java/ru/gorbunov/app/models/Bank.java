package ru.gorbunov.app.models;

import ru.gorbunov.app.models.accounts.Account;
import java.util.ArrayList;
import java.util.List;

public class Bank implements User {
    private final Roles role;
    private final String bankName;
    private int interestRate;
    private int percentageCommission;
    private final List<Account> accounts;
    private final List<Client> subscribers;


    public Bank(String bankName, int interestRate, int percentageCommission) {
        this.interestRate = interestRate;
        this.percentageCommission = percentageCommission;
        role = Roles.BANK;
        this.bankName = bankName;
        accounts = new ArrayList<>();
        subscribers = new ArrayList<>();
    }

    @Override
    public Roles getRole() {
        return role;
    }

    @Override
    public String getBankName() {
        return bankName;
    }

    @Override
    public boolean isVerified() {
        return true;
    }

    public int getIterestrate() {
        return interestRate;
    }

    public void setInterestrate(int interestRate) {
        this.interestRate = interestRate;
    }

    public int getPercentageCommission() {
        return percentageCommission;
    }

    public void setPercentageCommission(int percentageCommission) {
        this.percentageCommission = percentageCommission;
    }

    public List<Account> getAccounts() {
        return accounts;
    }

    public void sendNotifications(String notification) {
        for (var subscriber: subscribers) {
            subscriber.getNotification(notification);
        }
    }

    public void addAccount(Account account) {
        accounts.add(account);
    }
    public void addSubscriber(Client client) {
        subscribers.add(client);
    }
    public Account findAccount(int id) {
        for (var account : accounts) {
            if (account.checkId() == id) {
                return account;
            }
        }

        return null;
    }
}
