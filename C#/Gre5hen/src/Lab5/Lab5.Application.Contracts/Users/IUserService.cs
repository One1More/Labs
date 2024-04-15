using Lab5.Application.Models.Operations;

namespace Lab5.Application.Contracts.UserLogin;

public interface IUserService
{
    UserAccountFindResult CheckAccount(int number);
    UserLoginResult Login(int pinCode, int number);
    UserCheckBalanceResult CheckAccountBalance();
    UserBalanceOperationsResult MakeDeposit(long deposit);
    UserBalanceOperationsResult MakeWithdrawal(long money);
    OperationHistory CheckOperationHistory();
}