using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<UserAccountFindResult> FindUserByAccoutNumber(int number);
    Task<User?> TryToLogin(int pinCode, int number);
    Task<long> CheckAccountBalance(int number);
    Task MakeDeposit(int number, long money);
    Task<UserBalanceOperationsResult> MakeWithdrawal(int number, long money);
    Task<long> CheckMoneyAmount(int number);
    Task AddOperationToHistory(int number, Operation operation, long moneyAmount);
    Task<IEnumerable<IUserOperation>> CheckHistory(int number);
}