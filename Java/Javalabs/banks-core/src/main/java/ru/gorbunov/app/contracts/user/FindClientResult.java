package ru.gorbunov.app.contracts.user;

import ru.gorbunov.app.models.Client;

public interface FindClientResult {
    public final record Success(Client user) implements FindClientResult {}
    public final record Fail() implements FindClientResult {}
}
