package ru.gorbunov;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.reactive.function.client.WebClient;

@Configuration
public class OwnersClientConfig {
    @Value("${ownersUrl:http://localhost:8091}")
    private String baseUrl;

    @Bean
    public WebClient ownersClient(WebClient.Builder webClientBuilder) {
        return webClientBuilder
                .defaultHeader("Content-Type", "application/json")
                .baseUrl(baseUrl)
                .build();
    }
}
