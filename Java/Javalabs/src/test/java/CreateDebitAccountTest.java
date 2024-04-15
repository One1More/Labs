import org.junit.jupiter.api.Test;
import ru.gorbunov.app.application.bank.BankServiceImpl;

import ru.gorbunov.app.models.accounts.AccountTypes;
import ru.gorbunov.app.models.Bank;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.dataAccess.BankRepositoryImpl;
import ru.gorbunov.dataAccess.TransactionsRepositoryImpl;

import java.util.Optional;

import static org.junit.jupiter.api.Assertions.*;


public class CreateDebitAccountTest {
    @Test
    public void test_createDebitAccount_success() {
        // Arrange
        BankRepositoryImpl bankRepository = new BankRepositoryImpl();
        TransactionsRepositoryImpl transactionsRepository = new TransactionsRepositoryImpl();
        CurrentUser currentUser = new CurrentUser();
        BankServiceImpl bankService = new BankServiceImpl(null, bankRepository, transactionsRepository, currentUser);
        String bankName = "Bank A";
        int interestRate = 5;
        int percentageCommission = 2;
        Bank bank = new Bank(bankName, interestRate, percentageCommission);
        bankRepository.addBank(bank);
        currentUser.user = Optional.of(bank);
        int accountId = 123;

        // Act
        bankService.createDebitAccount(accountId);

        // Assert
        assertNotNull(bank.findAccount(accountId));
        assertEquals(AccountTypes.DEBIT, bank.findAccount(accountId).checkType());
    }

    @Test
    public void test_FindAccount_Nullfail() {
        // Arrange
        BankRepositoryImpl bankRepository = new BankRepositoryImpl();
        TransactionsRepositoryImpl transactionsRepository = new TransactionsRepositoryImpl();
        CurrentUser currentUser = new CurrentUser();
        BankServiceImpl bankService = new BankServiceImpl(null, bankRepository, transactionsRepository, currentUser);
        String bankName = "Bank A";
        int interestRate = 5;
        int percentageCommission = 2;
        Bank bank = new Bank(bankName, interestRate, percentageCommission);
        bankRepository.addBank(bank);
        int accountId = 123;

        // Assert
        assertNull(bank.findAccount(accountId));
    }

}