package ru.gorbunov.app.contracts.bank;

public interface WithdrawalResult {
    public final record Success () implements WithdrawalResult {}
    public final record InsufficientFunds () implements WithdrawalResult {}
    public final record Fail () implements WithdrawalResult {}
    public final record NotVerified () implements WithdrawalResult {}
}
