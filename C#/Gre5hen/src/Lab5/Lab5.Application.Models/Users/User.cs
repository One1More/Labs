namespace Lab5.Application.Models.Users;

public class User
{
    public User(int accountNumber, UserRole role)
    {
        AccountNumber = accountNumber;
        Role = role;
    }

    public int AccountNumber { get; }
    public UserRole Role { get; }
}