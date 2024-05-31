package ru.gorbunov;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.function.client.WebClient;

import java.util.List;

@Component
public class OwnersClientImpl implements OwnersClient {
    private final WebClient webClient;

    @Autowired
    public OwnersClientImpl(@Qualifier("ownersClient") WebClient webClient) {
        this.webClient = webClient;
    }

    @Override
    public List<OwnerReturnDto> getOwners() {
        return webClient.get()
                .uri("/api/v1/owners")
                .retrieve()
                .bodyToFlux(OwnerReturnDto.class)
                .collectList()
                .block();
    }

}
