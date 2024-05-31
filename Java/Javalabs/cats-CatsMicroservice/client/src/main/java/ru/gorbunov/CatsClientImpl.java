package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.function.client.WebClient;
import ru.gorbunov.dto.Breeds;
import ru.gorbunov.dto.CatReturnDto;
import ru.gorbunov.dto.Colors;

import java.util.List;

@Component
public class CatsClientImpl implements CatsClient {
    private final WebClient webClient;

    @Autowired
    public CatsClientImpl(@Qualifier("catsClient") WebClient webClient) {
        this.webClient = webClient;
    }

    @Override
    public List<CatReturnDto> getCats(Colors color, Breeds breed) {
        return webClient.get()
                .uri("/api/v1/cats?color={color}&breed={breed}", color, breed)
                .retrieve()
                .bodyToFlux(CatReturnDto.class)
                .collectList()
                .block();
    }
}
