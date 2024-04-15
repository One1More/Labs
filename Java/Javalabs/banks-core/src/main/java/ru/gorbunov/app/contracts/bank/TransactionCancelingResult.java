package ru.gorbunov.app.contracts.bank;

public interface TransactionCancelingResult {
    public final record Success() implements TransactionCancelingResult {}
    public final record Fail() implements TransactionCancelingResult {}
}
