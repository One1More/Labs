using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.AdminLogin;
using Lab5.Application.Models.Users;
using Lab5.Application.Users;

namespace Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private CurrentUser _currentUser;

    public AdminService(IAdminRepository repository, CurrentUser currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }

    public AdminLoginResult Login(int code)
    {
        User? user = _repository.TryToLogin(code).Result;

        if (user is null)
        {
            return new AdminLoginResult.WrongCode();
        }

        _currentUser.User = user;

        return new AdminLoginResult.Success();
    }

    public void CreateNewBancAccount(int number, int code)
    {
        _repository.CreateNewAccount(number, code);
    }

    public void ChangeSystemPassword(int newCode)
    {
        _repository.ChangeSystemPassword(newCode);
    }
}