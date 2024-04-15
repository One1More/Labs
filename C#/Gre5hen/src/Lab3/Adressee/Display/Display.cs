namespace Itmo.ObjectOrientedProgramming.Lab3.Adressee.Display;

public class Display : ITextAdressee
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void TakeMessage(string message)
    {
        _driver.CleanOutput();
        _driver.PrintMessage(message);
    }
}