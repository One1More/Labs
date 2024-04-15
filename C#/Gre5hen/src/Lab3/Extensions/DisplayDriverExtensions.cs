using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Adressee.Display;

namespace Itmo.ObjectOrientedProgramming.Lab3.Extensions;

public static class DisplayDriverExtensions
{
    public static IDisplayDriver WithColour(this IDisplayDriver displayDriver, Color color)
    {
        return new ModifiedDisplayDriver(displayDriver, color);
    }
}