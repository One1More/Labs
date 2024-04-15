import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.ObjectWriter;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;
import org.junit.jupiter.api.extension.ExtendWith;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import ru.gorbunov.Main;
import ru.gorbunov.dto.CatDto;
import ru.gorbunov.models.Breeds;
import ru.gorbunov.models.Colors;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;

import java.nio.charset.StandardCharsets;
import java.time.LocalDate;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
//@ExtendWith(SpringExtension.class)
//@TestPropertySource(
//        properties = {
//                "spring.datasource.url=jdbc:h2:mem:testdb;DB_CLOSE_ON_MVCC=FALSE",
//                "spring.datasource.driverClassName=org.h2.Driver",
//                "spring.jpa.database-platform=org.hibernate.dialect.H2Dialect"
//        }
//)
@SpringBootTest(classes = Main.class)
@AutoConfigureMockMvc
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_EACH_TEST_METHOD)
public class CatControllerTest {
    public static final
    MediaType APPLICATION_JSON_UTF8 = new MediaType(
            MediaType.APPLICATION_JSON.getType(),
            MediaType.APPLICATION_JSON.getSubtype(),
            StandardCharsets.UTF_8);

    @Autowired
    private MockMvc mockMvc;

    private final ObjectMapper objectMapper = new ObjectMapper().registerModule(new JavaTimeModule());
    private final ObjectWriter ow = objectMapper.writer().withDefaultPrettyPrinter();

    @Test
    public void addCats() throws Exception {

        var firstCat = new CatDto("Yoric", LocalDate.now(), Breeds.ABYSSINIAN, Colors.WHITE);

        var secondCat = new CatDto("SMB", LocalDate.now(), Breeds.ABYSSINIAN, Colors.BLACK);

         mockMvc.perform(
                        post("/api/v1/cats")
                                .contentType(APPLICATION_JSON_UTF8)
                                .content(ow.writeValueAsString(firstCat)))
                .andDo(print())
                .andExpect(status().isOk());

        mockMvc.perform(
                        post("/api/v1/cats")
                                .contentType(APPLICATION_JSON_UTF8)
                                .content(ow.writeValueAsString(secondCat)))
                .andDo(print())
                .andExpect(status().isOk());

        mockMvc.perform(
                        get("/api/v1/cats")
                                .contentType(APPLICATION_JSON_UTF8)
                                .content(ow.writeValueAsString(secondCat)))
                .andDo(print())
                .andExpect(status().isOk());

    }
}