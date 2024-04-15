package ru.gorbunov.app.contracts.bank;

public interface TopUpResult {
    public final record Success() implements TopUpResult {}
    public final record Fail() implements TopUpResult {}
    public final record NotVerified() implements TopUpResult {}
}
