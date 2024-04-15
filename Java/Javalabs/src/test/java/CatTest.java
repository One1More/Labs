import org.junit.jupiter.api.Test;
import org.mockito.Mockito;
import ru.gorbunov.CatsController;

import ru.gorbunov.contracts.CatsService;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.models.Breeds;
import ru.gorbunov.models.Colors;

import java.time.LocalDate;

public class CatTest {


    @Test
    public void test_addCat_validInput() {
        // Arrange
//        CatsService mockService = Mockito.mock(CatsService.class);
//        CatsController controller = new CatsController(mockService);
//        long id = 1;
//        String name = "Fluffy";
//        LocalDate birthDate = LocalDate.of(2020, 1, 1);
//        Breeds breed = Breeds.ABYSSINIAN;
//        Colors color = Colors.BLACK;
//
//        // Act
//        controller.addCat(name, birthDate, breed, color);
//
//        // Assert
//        Mockito.verify(mockService).addCat(Mockito.any(CatDto.class));
    }

    @Test
    public void test_addFriendToCatWithNoFriends() {
        // Arrange
        long catId = 1;
        long friendId = 2;
        CatsService mockService = Mockito.mock(CatsService.class);
        CatsController controller = new CatsController(mockService);

        // Act
        controller.addCatFriend(catId, friendId);

        // Assert
        Mockito.verify(mockService).addCatFriend(catId, friendId);
    }
}