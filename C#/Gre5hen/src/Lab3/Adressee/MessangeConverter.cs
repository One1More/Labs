using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee;

public class MessangeConverter : IAdressee
{
    private readonly ITextAdressee _adressee;

    public MessangeConverter(ITextAdressee adressee)
    {
        _adressee = adressee;
    }

    public void TakeMessage(Message message)
    {
        _adressee.TakeMessage(Convert(message));
    }

    private static string Convert(Message message)
    {
        var strBuilder = new StringBuilder();
        strBuilder.Append(message.Header);
        strBuilder.AppendLine();
        strBuilder.AppendLine();
        strBuilder.Append(message.Body);
        strBuilder.AppendLine();

        return strBuilder.ToString();
    }
}