using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAdminRepository
{
    Task<User?> TryToLogin(int code);
    Task CreateNewAccount(int number, int pinCode);
    Task ChangeSystemPassword(int pinCode);
}