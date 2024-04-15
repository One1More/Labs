using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private CurrentUser _currentUser;

    public UserService(IUserRepository repository, CurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public UserAccountFindResult CheckAccount(int number)
    {
        return _repository.FindUserByAccoutNumber(number).Result;
    }

    public UserLoginResult Login(int pinCode, int number)
    {
        User? user = _repository.TryToLogin(pinCode, number).Result;

        if (user is null)
        {
            return new UserLoginResult.Fail();
        }

        _currentUser.User = user;
        return new UserLoginResult.Success();
    }

    public UserCheckBalanceResult CheckAccountBalance()
    {
        if (_currentUser.User is null)
        {
            return new UserCheckBalanceResult.WrongUser();
        }

        long balance = _repository.CheckAccountBalance(_currentUser.User.AccountNumber).Result;

        return new UserCheckBalanceResult.Success(balance);
    }

    public UserBalanceOperationsResult MakeDeposit(long deposit)
    {
        if (deposit <= 0)
        {
            return new UserBalanceOperationsResult.MoneyLowerZero();
        }

        if (_currentUser.User != null)
        {
            _repository.MakeDeposit(_currentUser.User.AccountNumber, deposit);

            return new UserBalanceOperationsResult.Success();
        }

        return new UserBalanceOperationsResult.InsufficientFunds();
    }

    public UserBalanceOperationsResult MakeWithdrawal(long money)
    {
        if (money <= 0)
        {
            return new UserBalanceOperationsResult.MoneyLowerZero();
        }

        if (_currentUser.User != null)
        {
            if (_repository.MakeWithdrawal(_currentUser.User.AccountNumber, money).Result is not
                UserBalanceOperationsResult.Success)
            {
                return new UserBalanceOperationsResult.InsufficientFunds();
            }
        }

        return new UserBalanceOperationsResult.Success();
    }

    public OperationHistory CheckOperationHistory()
    {
        if (_currentUser.User != null)
        {
            IEnumerable<IUserOperation> operations = _repository.CheckHistory(_currentUser.User.AccountNumber).Result;

            var history = new OperationHistory(operations);
            return history;
        }

        return new OperationHistory(Array.Empty<IUserOperation>());
    }
}