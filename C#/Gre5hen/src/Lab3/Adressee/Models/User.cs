using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Models;

public class User : IAdressee
{
    private List<ViewableMessage> _messages;

    public User()
    {
        _messages = new List<ViewableMessage>();
    }

    public IReadOnlyList<ViewableMessage> Messages => _messages;

    public void TakeMessage(Message message)
    {
        var viewableMessage = new ViewableMessage(message);
        _messages.Add(viewableMessage);
    }
}