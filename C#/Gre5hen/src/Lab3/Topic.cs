using Itmo.ObjectOrientedProgramming.Lab3.Adressee;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Topic
{
    private IAdressee _adressee;

    public Topic(string header, IAdressee adressee, Message message)
    {
        Header = header;
        _adressee = adressee;
        Message = message;
    }

    public string Header { get; }
    public Message Message { get; }

    public void SendAdresseeMessage()
    {
        _adressee.TakeMessage(Message);
    }
}