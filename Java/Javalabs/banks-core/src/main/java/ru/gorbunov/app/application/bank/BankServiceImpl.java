package ru.gorbunov.app.application.bank;
import org.springframework.stereotype.Service;
import ru.gorbunov.app.application.centralBank.CentralBankServiceImpl;
import ru.gorbunov.app.contracts.bank.*;
import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.models.*;
import ru.gorbunov.app.models.accounts.CreditAccount;
import ru.gorbunov.app.models.accounts.DebitAccount;
import ru.gorbunov.app.models.accounts.DepositAccount;
import ru.gorbunov.dataAccess.BankRepositoryImpl;
import ru.gorbunov.dataAccess.TransactionsRepositoryImpl;


import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class BankServiceImpl implements BankService {
    private final CentralBankServiceImpl centralBankService;
    private final BankRepositoryImpl bankRepository;
    private final TransactionsRepositoryImpl transactionsRepository;
    private final CurrentUser currentUser;

    public BankServiceImpl(CentralBankServiceImpl centralBankService, BankRepositoryImpl bankRepository, TransactionsRepositoryImpl transactionsRepository, CurrentUser currentUser) {
        this.centralBankService = centralBankService;
        this.bankRepository = bankRepository;
        this.transactionsRepository = transactionsRepository;
        this.currentUser = currentUser;
    }

    @Override
    public LoginResult loginAsBank(String name) {
        var result = bankRepository.findBank(name);

        if (result instanceof FindBankResult.Success res) {
            currentUser.user = Optional.of(res.bank());

            return new LoginResult.Success();
        }

        return new LoginResult.Fail();
    }

    @Override
    public WithdrawalResult withdraw(int accountId, int money) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            if (bankRes.bank().findAccount(accountId) != null)
                if (bankRes.bank().findAccount(accountId).withdraw(money) instanceof WithdrawalResult.Success) {
                    transactionsRepository.addTransaction(new Transaction(accountId, money, TransactionType.Withdraw, User.getBankName()));

                    return new WithdrawalResult.Success();
                } else if (bankRes.bank().findAccount(accountId).withdraw(money) instanceof WithdrawalResult.NotVerified) {
                    return new WithdrawalResult.NotVerified();

                } else return new WithdrawalResult.Fail();

            return new WithdrawalResult.InsufficientFunds();
        }

        return new WithdrawalResult.Fail();
    }

    @Override
    public TopUpResult topUp(int accountId, int money) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            if (bankRes.bank().findAccount(accountId) != null) {
                if (bankRes.bank().findAccount(accountId).topUp(money) instanceof TopUpResult.NotVerified) {
                    return new TopUpResult.Fail();
                }

                transactionsRepository.addTransaction(new Transaction(accountId, money, TransactionType.DEPOSIT, User.getBankName()));

                return new TopUpResult.Success();
            }

            return new TopUpResult.Fail();
        }

        return new TopUpResult.Fail();
    }

    @Override
    public void createDebitAccount(int accountId) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            var newAccount = new DebitAccount(accountId, bankRes.bank().getIterestrate());
            newAccount.setVerification(User.isVerified());
            bankRes.bank().addAccount(newAccount);
        }
    }

    @Override
    public void createDepositAccount(int accountId) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            var newAccount = new DepositAccount(accountId,bankRes.bank().getIterestrate());
            newAccount.setVerification(User.isVerified());
            bankRes.bank().addAccount(newAccount);
        }
    }

    @Override
    public void createCreditAccount(int accountId) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            var newAccount = new CreditAccount(accountId, bankRes.bank().getPercentageCommission());
            newAccount.setVerification(User.isVerified());
            bankRes.bank().addAccount(newAccount);
        }
    }

    @Override
    public TransferResult transfer(int accountId,
                                   int recipientId,
                                   String recipientBankName,
                                   int money) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            if (bankRes.bank().findAccount(accountId) == null) {
                return new TransferResult.WrongYourAccountId();
            }

            if (User.getBankName().equals(recipientBankName)) {
                if (bankRes.bank().findAccount(accountId).withdraw(money) instanceof WithdrawalResult.Success) {
                    if (bankRes.bank().findAccount(recipientId) != null) {
                        bankRes.bank().findAccount(recipientId).topUp(money);

                        return new TransferResult.Success();
                    }

                    return new TransferResult.WrongRecipientAccountId();
                }
            } else {
                if (centralBankService.Transfer(recipientId, recipientBankName) instanceof ru.gorbunov.app.contracts.centralBank.TransferResult.Success res) {
                    if (bankRes.bank().findAccount(accountId).withdraw(money) instanceof WithdrawalResult.Success) {
                        res.account().topUp(money);

                        return new TransferResult.Success();
                    }
                } else if (centralBankService.Transfer(recipientId, recipientBankName) instanceof ru.gorbunov.app.contracts.centralBank.TransferResult.WrongBankName) {
                    return new TransferResult.WrongRecipientBankName();
                } else {
                    return new TransferResult.WrongRecipientAccountId();
                }
            }
        }

        return new TransferResult.Fail();
    }

    @Override
    public void updateConditions(int interestRate, int commission) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            bankRes.bank().setInterestrate(interestRate);
            bankRes.bank().setPercentageCommission(commission);
        }
    }

    @Override
    public void scipTime(int days) {
        var User = bankRepository.findBank(currentUser.user.get().getBankName())
                instanceof FindBankResult.Success bankRes ? bankRes.bank() : null;

        for (int i = 0; i < days; i++) {
            for (var account : User.getAccounts()) {
                account.doDailyAction();
            }
        }
    }

    @Override
    public int getBalance(int accountId) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            if (bankRes.bank().findAccount(accountId) != null) {
                return bankRes.bank().findAccount(accountId).checkMoney();
            }
        }

        return 0;
    }

    @Override
    public TransactionCancelingResult cancelTransaction(String id) {
        var transaction = transactionsRepository.findTransaction(id);

        if (transaction.isPresent()) {
            if (transaction.get().getType() == TransactionType.Withdraw) {
                topUp(transaction.get().getAccountId(), transaction.get().getMoney());
            } else {
                withdraw(transaction.get().getAccountId(), transaction.get().getMoney());
            }

            return new TransactionCancelingResult.Success();
        }

        return new TransactionCancelingResult.Fail();
    }

    @Override
    public List<TransactionTransfer> getBankTransactions() {
        List<TransactionTransfer> transactionsList = new ArrayList<>();

        var transactions = transactionsRepository.getTransactions(currentUser.user.get().getBankName());

        for (var transaction: transactions) {
            transactionsList.add(new TransactionTransfer(transaction.getId(), transaction.getAccountId(), transaction.getMoney(), transaction.getType()));
        }

        return transactionsList;
    }

    @Override
    public void addSubscriber() {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            bankRes.bank().addSubscriber((Client) User);
        }
    }

    @Override
    public void sendNotifications(String notification) {
        var User = currentUser.user.get();

        if (bankRepository.findBank(User.getBankName()) instanceof FindBankResult.Success bankRes) {
            bankRes.bank().sendNotifications(notification);
        }
    }
}
