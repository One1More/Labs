package ru.gorbunov;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.reactive.function.client.WebClient;

@Configuration
public class CatsClientConfig {
    @Value("${catsUrl:http://localhost:8090}")
    private String baseUrl;

    @Bean
    public WebClient catsClient(WebClient.Builder webClientBuilder) {
        return webClientBuilder
                .defaultHeader("Content-Type", "application/json")
                .baseUrl(baseUrl)
                .build();
    }
}
