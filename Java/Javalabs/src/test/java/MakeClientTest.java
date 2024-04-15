import org.junit.jupiter.api.Test;
import ru.gorbunov.app.abstractions.UserRepository;
import ru.gorbunov.app.application.user.ClientServiceImpl;

import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.contracts.user.FindClientResult;
import ru.gorbunov.app.models.Client;
import ru.gorbunov.app.models.CurrentUser;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;


public class MakeClientTest {


    @Test
    public void test_createClient_successfully() {
        // Arrange
        UserRepository userRepository = mock(UserRepository.class);
        CurrentUser currentUser = mock(CurrentUser.class);
        ClientServiceImpl clientService = new ClientServiceImpl(userRepository, currentUser);
    
        String name = "John";
        String surname = "Doe";
        String address = "123 Main St";
        Integer passportNumber = 123456789;
        String bankName = "Bank of America";
    
        // Act
        clientService.makeClient(name, surname, address, passportNumber, bankName);
    
        // Assert
        verify(userRepository, times(1)).addClient(any(Client.class));
    }

    @Test
    public void test_findClient_successfully() {
        // Arrange
        UserRepository userRepository = mock(UserRepository.class);
        CurrentUser currentUser = mock(CurrentUser.class);
        ClientServiceImpl clientService = new ClientServiceImpl(userRepository, currentUser);

        String name = "John";
        String surname = "Doe";

        FindClientResult.Success result = new FindClientResult.Success(new Client(name, surname, "123 Main St", 123456789, "Bank of America"));
        when(userRepository.findClient(name, surname)).thenReturn(result);

        // Act
        LoginResult loginResult = clientService.tryLogin(name, surname);

        // Assert
        assertTrue(loginResult instanceof LoginResult.Success);
    }
}