package ru.gorbunov.presentation;



import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;

import java.util.List;

@Configuration
@ComponentScan(basePackages = {"ru/gorbunov/presentation",
        "ru/gorbunov/presentation.scriptProviders",
        "presentation.scripts",
        "ru/gorbunov/app.models",
        "ru/gorbunov/app.application.centralBank",
        "ru/gorbunov/app.application.bank",
        "ru/gorbunov/app.application.user",
        "ru/gorbunov/dataAccess"})
public class AppConfig {
    @Bean
    public ScriptRunner scriptRunner(List<ScriptProvider> scriptProviders) {
        return new ScriptRunner(scriptProviders);
    }
}

