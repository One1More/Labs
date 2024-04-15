package ru.gorbunov.app.application.centralBank;

import org.springframework.stereotype.Service;
import ru.gorbunov.app.abstractions.BankRepository;
import ru.gorbunov.app.contracts.bank.FindBankResult;
import ru.gorbunov.app.contracts.centralBank.CentralBankService;
import ru.gorbunov.app.contracts.LoginResult;
import ru.gorbunov.app.contracts.centralBank.TransferResult;
import ru.gorbunov.app.models.Bank;
import ru.gorbunov.app.models.CentralBank;
import ru.gorbunov.app.models.CurrentUser;

import java.util.Objects;
import java.util.Optional;

@Service
public class CentralBankServiceImpl implements CentralBankService {
    private final CurrentUser currentUser;
    private final BankRepository repository;

    public CentralBankServiceImpl(CurrentUser currentUser, BankRepository repository) {
        this.currentUser = currentUser;
        this.repository = repository;
    }

    @Override
    public LoginResult tryToLogIn(String someCode) {
        if (Objects.equals(someCode, "Central bank")) {
            currentUser.user = Optional.of(new CentralBank());

            return new LoginResult.Success();
        }

        return new LoginResult.Fail();
    }

    @Override
    public void createNewBank(String name, int rate, int commission) {
        repository.addBank(new Bank(name, rate, commission));
    }

    @Override
    public TransferResult Transfer(int recipientId, String recipientBankName) {
        if (repository.findBank(recipientBankName) instanceof FindBankResult.Success recipientRes) {
            if (recipientRes.bank().findAccount(recipientId) != null) {
                return new TransferResult.Success(recipientRes.bank().findAccount(recipientId));
            }

            return new TransferResult.Fail();
        }

        return new TransferResult.WrongBankName();
    }
}
