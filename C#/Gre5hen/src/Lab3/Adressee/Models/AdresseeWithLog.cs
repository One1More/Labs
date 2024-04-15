namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee;

public class AdresseeWithLog : IAdressee
{
    private readonly IAdressee _adressee;

    private readonly ILogger _logger;

    public AdresseeWithLog(IAdressee adressee, ILogger logger)
    {
        _adressee = adressee;
        _logger = logger;
    }

    public void TakeMessage(Message message)
    {
        _logger.LogMessage($"{message.Header}\n{message.Body}\n");
        _adressee.TakeMessage(message);
    }
}