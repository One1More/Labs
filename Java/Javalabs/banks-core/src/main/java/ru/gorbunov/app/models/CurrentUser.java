package ru.gorbunov.app.models;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

import java.util.Optional;

@Component
@Scope("singleton")
public class CurrentUser {
    public Optional<User> user;

    public CurrentUser() {
        user = Optional.empty();
    }
}
