package ru.gorbunov.app.contracts.bank;

public interface TransferResult {
    public final record Success() implements TransferResult {}
    public final record WrongYourAccountId() implements TransferResult {}
    public final record WrongRecipientBankName() implements TransferResult {}
    public final record WrongRecipientAccountId() implements TransferResult {}
    public final record InsufficientFunds() implements TransferResult {}
    public final record Fail() implements TransferResult {}
}
