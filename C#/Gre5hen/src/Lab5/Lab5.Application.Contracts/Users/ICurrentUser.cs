using Lab5.Application.Models.Users;

namespace Lab5.Application.Contracts.UserLogin;

public interface ICurrentUser
{
    User? User { get; set; }
}