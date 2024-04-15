package ru.gorbunov.dataAccess;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;
import ru.gorbunov.app.abstractions.BankRepository;
import ru.gorbunov.app.contracts.bank.FindBankResult;
import ru.gorbunov.app.models.Bank;

import java.util.ArrayList;
import java.util.List;

@Component
@Scope("singleton")
public class BankRepositoryImpl implements BankRepository {
    private List<Bank> banks;

    public BankRepositoryImpl() {
        banks = new ArrayList<>();
    }

    @Override
    public FindBankResult findBank(String name) {
        for (Bank bank : banks) {
            if (bank.getBankName().equals(name)) {
                return new FindBankResult.Success(bank);
            }
        }

        return new FindBankResult.Fail();
    }

    @Override
    public void addBank(Bank bank) {
        banks.add(bank);
    }
}
