using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.Models;

public class TreeListContext
{
    public TreeListContext(string depth)
    {
        Depth = int.Parse(depth, CultureInfo.CurrentCulture);
    }

    public int Depth { get; }
}