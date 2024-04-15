
import org.junit.jupiter.api.Test;
import ru.gorbunov.app.application.bank.BankServiceImpl;
import ru.gorbunov.app.contracts.bank.TransactionCancelingResult;
import ru.gorbunov.app.models.Client;
import ru.gorbunov.app.models.CurrentUser;
import ru.gorbunov.app.models.Transaction;
import ru.gorbunov.app.models.TransactionType;
import ru.gorbunov.dataAccess.TransactionsRepositoryImpl;

import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertNotNull;
import static org.junit.jupiter.api.Assertions.assertTrue;
import static org.mockito.Mockito.*;

public class CancelTransactionTest {
        @Test
        public void test_transactionCreated_successfully() {
            // Arrange
            int accountId = 1;
            int money = 100;
            TransactionType type = TransactionType.Withdraw;

            TransactionsRepositoryImpl transactionsRepository = new TransactionsRepositoryImpl();
            CurrentUser currentUser = new CurrentUser();
            BankServiceImpl bankService = new BankServiceImpl(null,null, transactionsRepository, currentUser);
            currentUser.user = Optional.of(new Client("Test", "test", "test", 123, "BankName"));


            Transaction transaction = new Transaction(accountId, money, type, "BankName");
            transactionsRepository.addTransaction(transaction);

            // Act
            var result = transactionsRepository.findTransaction(transaction.getId().toString());

            // Assert
            assertNotNull(result);
        }
        @Test
        public void test_cancelUnrealTransaction_Fail() {
            // Arrange
            int accountId = 1;
            int money = -100;
            TransactionType type = TransactionType.DEPOSIT;

            TransactionsRepositoryImpl transactionsRepository = mock(TransactionsRepositoryImpl.class);
            CurrentUser currentUser = new CurrentUser();
            BankServiceImpl bankService = new BankServiceImpl(null,null, transactionsRepository, currentUser);
            currentUser.user = Optional.of(new Client("Test", "test", "test", 123, "Test"));


            when(transactionsRepository.findTransaction("someid")).thenReturn(Optional.empty());

            // Act
            TransactionCancelingResult result = bankService.cancelTransaction(null);

            // Assert
            assertTrue(result instanceof TransactionCancelingResult.Fail);
        }

}