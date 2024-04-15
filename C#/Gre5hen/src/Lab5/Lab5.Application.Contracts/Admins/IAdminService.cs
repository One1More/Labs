namespace Lab5.Application.Contracts.AdminLogin;

public interface IAdminService
{
    AdminLoginResult Login(int code);
    void CreateNewBancAccount(int number, int code);
    void ChangeSystemPassword(int newCode);
}