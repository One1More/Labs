//import org.junit.Test;
//import ru.gorbunov.dao.CatsRepositoryImpl;
//import ru.gorbunov.models.Breeds;
//import ru.gorbunov.models.Cat;
//import ru.gorbunov.models.Colors;
//
//import java.time.LocalDate;
//import java.util.ArrayList;
//import java.util.List;
//
//import static org.junit.Assert.assertEquals;
//import static org.mockito.Mockito.*;
//
//public class RepTest {
//
//    @Test
//    public void test_deleteCat_minimumValidId() {
//        // Arrange
//        long id = Long.MIN_VALUE;
//        CatsRepositoryImpl catsRepository = mock(CatsRepositoryImpl.class);
//
//        // Act
//        catsRepository.deleteCat(id);
//
//        // Assert
//        verify(catsRepository, times(1)).deleteCat(id);
//    }
//
//    @Test
//    public void test_returnsAllCats() {
//        // Arrange
//        CatsRepositoryImpl catsRepository = mock(CatsRepositoryImpl.class);
//        List<Cat> expectedCats = new ArrayList<>();
//
//        expectedCats.add(new Cat(1, "Cat1", LocalDate.now(), Breeds.ABYSSINIAN, Colors.BLACK));
//        expectedCats.add(new Cat(2, "Cat2", LocalDate.now(), Breeds.ABYSSINIAN, Colors.BLACK));
//        when(catsRepository.getAllCats()).thenReturn(expectedCats);
//
//        // Act
//        List<Cat> actualCats = catsRepository.getAllCats();
//
//        // Assert
//        assertEquals(expectedCats, actualCats);
//    }
//}
