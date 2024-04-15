using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Lab5.Application.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankSystemTests
{
    [Fact]
    public void WithdrawalMoneyShouldReturnNotEnoughMoney()
    {
        IUserRepository mock = Substitute.For<IUserRepository>();
        var currentuser = new CurrentUser();
        currentuser.User = new User(2424, UserRole.User);
        var service = new UserService(mock, currentuser);

        service.MakeWithdrawal(10);

        mock.Received().MakeWithdrawal(2424, 10);
    }

    [Fact]
    public void DepositShouldReturnSuccess()
    {
        IUserRepository mock = Substitute.For<IUserRepository>();
        var currentuser = new CurrentUser();
        currentuser.User = new User(2424, UserRole.User);
        var service = new UserService(mock, currentuser);

        service.MakeDeposit(10);

        mock.Received().MakeDeposit(2424, 10);
    }

    [Fact]
    public void WithdrawalShouldReturnSuccess()
    {
        IUserRepository mock = Substitute.For<IUserRepository>();
        var currentuser = new CurrentUser();
        currentuser.User = new User(2424, UserRole.User);
        var service = new UserService(mock, currentuser);

        service.MakeWithdrawal(10);

        mock.Received().MakeWithdrawal(2424, 10);
    }
}