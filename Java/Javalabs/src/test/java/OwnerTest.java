import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import ru.gorbunov.contracts.OwnersRepository;
import ru.gorbunov.dto.OwnerDto;
import ru.gorbunov.models.Owner;
import ru.gorbunov.services.OwnersServiceImpl;


import java.time.LocalDate;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

public class OwnerTest {


    @Test
    public void test_deleteOwner_success() {
        // Arrange
//        long id = 1;
//        OwnersRepository mockRepository = Mockito.mock(OwnersRepository.class);
//        OwnersServiceImpl ownersService = new OwnersServiceImpl(mockRepository);
//
//        // Act
//        ownersService.deleteOwner(id);
//
//        // Assert
//        Mockito.verify(mockRepository).deleteOwner(id);
    }

    @Test
    public void test_updateOwnerInfo_validInput() {
        // Arrange
//        OwnersRepository mockRepository = mock(OwnersRepository.class);
//        OwnersServiceImpl ownersService = new OwnersServiceImpl(mockRepository);
//        OwnerDto dto = new OwnerDto("John Doe", LocalDate.of(1990, 1, 1));
//        Owner owner = new Owner(dto.getName(), dto.getBirthDate());
//
//        // Act
//        ownersService.changeOwnerInfo(dto);
//
//        // Assert
//        verify(mockRepository, times(1)).updateOwner(owner);
    }
}