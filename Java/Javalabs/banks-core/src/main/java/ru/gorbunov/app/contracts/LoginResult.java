package ru.gorbunov.app.contracts;

public interface LoginResult {
    public final record Success() implements LoginResult {}
    public final record Fail() implements LoginResult {}
}
