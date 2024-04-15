using System;
using System.Collections.Generic;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab3.AdreseeBuilders;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class CorporateMailSystemTests
{
    [Fact]
    public void UserMessageShouldReturnNonRead()
    {
        var user = new User();
        var message = new Message("Hi", "I'm somebody", 0);
        var topic = new Topic("UserMessage", user, message);

        topic.SendAdresseeMessage();

        Assert.Equal(user.Messages[0].CheckMessageStatus(), new MessageReadStatus.MessageIsNotRead());
    }

    [Fact]
    public void UserMessageShouldReturnRead()
    {
        var user = new User();
        var message = new Message("Hi", "I'm somebody", 0);
        var topic = new Topic("UserMessage", user, message);

        topic.SendAdresseeMessage();
        user.Messages[0].ReadMessage();

        Assert.Equal(user.Messages[0].CheckMessageStatus(), new MessageReadStatus.MessageRead());
    }

    [Fact]
    public void UserMessageShouldReturnException()
    {
        var user = new User();
        var message = new Message("Hi", "I'm somebody", 0);
        var topic = new Topic("UserMessage", user, message);

        topic.SendAdresseeMessage();
        user.Messages[0].ReadMessage();

        Assert.Throws<ArgumentException>(() => user.Messages[0].ReadMessage());
    }

    [Fact]
    public void AdresseeProxyShouldntTakeMessage()
    {
        var message = new Message("Hi", "I'm somebody", 3);

        IAdressee mockProxyUser = Substitute.For<IAdressee>();
        var proxyUser = new ProxyAdressee(mockProxyUser, new List<int>() { 0, 1, 2 });
        var topic = new Topic("smth", proxyUser, message);

        topic.SendAdresseeMessage();

        mockProxyUser.DidNotReceive().TakeMessage(message);
    }

    [Fact]
    public void AdresseeLogerTest()
    {
        var message = new Message("Hi", "I'm somebody", 3);

        Logger mock = Substitute.For<Logger>();
        IAdressee user = new UserBuilder()
            .WithLogger(mock)
            .Build();
        var topic = new Topic("smth", user, message);

        topic.SendAdresseeMessage();

        mock.Received().LogMessage($"{message.Header}\n{message.Body}\n");
    }

    [Fact]
    public void MessangerShouldWork()
    {
        ITextAdressee mock = Substitute.For<ITextAdressee>();
        var message = new Message("Hi", "I'm somebody", 0);
        var convertor = new MessangeConverter(mock);
        var topic = new Topic("UserMessage", convertor, message);

        var strBuilder = new StringBuilder();
        strBuilder.Append(message.Header);
        strBuilder.AppendLine();
        strBuilder.AppendLine();
        strBuilder.Append(message.Body);
        strBuilder.AppendLine();

        topic.SendAdresseeMessage();

        mock.Received().TakeMessage(strBuilder.ToString());
    }
}