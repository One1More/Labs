import org.junit.jupiter.api.Test;
import ru.gorbunov.app.application.bank.BankServiceImpl;

import ru.gorbunov.app.contracts.bank.FindBankResult;
import ru.gorbunov.app.contracts.bank.WithdrawalResult;
import ru.gorbunov.app.models.accounts.Account;
import ru.gorbunov.app.models.Bank;
import ru.gorbunov.app.models.Client;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Transaction;
import ru.gorbunov.dataAccess.BankRepositoryImpl;
import ru.gorbunov.dataAccess.TransactionsRepositoryImpl;

import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.Mockito.*;

public class WithdrawTest {

        @Test
        public void test_withdrawValid_amount() {
            // Arrange
            BankRepositoryImpl bankRepository = mock(BankRepositoryImpl.class);
            TransactionsRepositoryImpl transactionsRepository = mock(TransactionsRepositoryImpl.class);
            CurrentUser currentUser = new CurrentUser();
            BankServiceImpl bankService = new BankServiceImpl(null, bankRepository, transactionsRepository, currentUser);

            int accountId = 123;
            int money = 100;
            currentUser.user = Optional.of(new Client("Test", "test", "test", 123, "Test"));

            Bank bank = mock(Bank.class);
            Account account = mock(Account.class);

            when(bankRepository.findBank(anyString())).thenReturn(new FindBankResult.Success(bank));
            when(bank.findAccount(accountId)).thenReturn(account);
            when(account.withdraw(money)).thenReturn(new WithdrawalResult.Success());

            // Act
            WithdrawalResult result = bankService.withdraw(accountId, money);

            // Assert
            verify(transactionsRepository).addTransaction(any(Transaction.class));
            assertEquals(new WithdrawalResult.Success(), result);
        }

        @Test
        public void test_withdrawNonExisting_account() {
            // Arrange
            BankRepositoryImpl bankRepository = mock(BankRepositoryImpl.class);
            TransactionsRepositoryImpl transactionsRepository = mock(TransactionsRepositoryImpl.class);
            CurrentUser currentUser = new CurrentUser();
            BankServiceImpl bankService = new BankServiceImpl(null, bankRepository, transactionsRepository, currentUser);

            int accountId = 123;
            int money = 100;
            currentUser.user = Optional.of(new Client("Test", "test", "test", 123, "Test"));

            Bank bank = mock(Bank.class);

            when(bankRepository.findBank(anyString())).thenReturn(new FindBankResult.Success(bank));
            when(bank.findAccount(accountId)).thenReturn(null);

            // Act
            WithdrawalResult result = bankService.withdraw(accountId, money);

            // Assert
            verify(transactionsRepository, never()).addTransaction(any(Transaction.class));
            assertEquals(new WithdrawalResult.InsufficientFunds(), result);
        }
}