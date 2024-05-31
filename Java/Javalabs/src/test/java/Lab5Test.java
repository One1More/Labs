import org.junit.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.security.config.annotation.method.configuration.EnableMethodSecurity;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.TestPropertySource;
import org.springframework.test.context.jdbc.Sql;
import org.springframework.test.context.junit.jupiter.SpringExtension;
import org.springframework.test.context.junit4.SpringRunner;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import ru.gorbunov.CatsClientImpl;
import ru.gorbunov.KafkaProducer;
import ru.gorbunov.Main;

import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@RunWith(SpringRunner.class)
@ExtendWith(SpringExtension.class)
@SpringBootTest(classes = Main.class)
@EnableMethodSecurity
@TestPropertySource(
        properties = {
                "spring.datasource.url=jdbc:h2:mem:testdb;",
                "spring.datasource.driverClassName=org.h2.Driver",
                "spring.jpa.database-platform=org.hibernate.dialect.H2Dialect"
        }
)
@DirtiesContext(classMode = DirtiesContext.ClassMode.BEFORE_EACH_TEST_METHOD)
@AutoConfigureMockMvc
public class Lab5Test {
    @Autowired
    private MockMvc mockMvc;
    private String jwtToken;
    @MockBean
    private CatsClientImpl catsClient;
    @MockBean
    private KafkaProducer kafkaProducer;


    @Sql(scripts = {"/AddUser.sql"})
    @Test
    public void getCatsTest() throws Exception {
        jwtToken = mockMvc.perform(MockMvcRequestBuilders.post("/api/v1/auth/authenticate")
                        .contentType("application/json")
                        .content("{\"login\":\"user\",\"password\":\"password\"}"))
                .andReturn().getResponse().getContentAsString();

        mockMvc.perform(MockMvcRequestBuilders.get("/api/v1/cats")
                        .header("Authorization", "Bearer " + jwtToken))
                .andExpect(status().isOk());
    }
}