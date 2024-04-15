using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class ViewableMessage : IRenderable
{
    private Message _message;
    private bool _messageVieved;

    public ViewableMessage(Message message)
    {
        _message = message;
        _messageVieved = false;
    }

    public void ReadMessage()
    {
        if (!_messageVieved) _messageVieved = true;
        else throw new ArgumentException($"Message is already viewed.");
    }

    public MessageReadStatus CheckMessageStatus()
    {
        if (!_messageVieved) return new MessageReadStatus.MessageIsNotRead();
        else return new MessageReadStatus.MessageRead();
    }

    public void Render()
    {
        _message.Render();
    }
}