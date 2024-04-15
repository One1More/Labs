using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

public class CurrentUser : ICurrentUser
{
    public User? User { get; set; }
}