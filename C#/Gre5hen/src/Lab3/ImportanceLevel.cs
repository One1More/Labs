using System;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class ImportanceLevel
{
    public ImportanceLevel(int level)
    {
        if (level < 0) throw new ArgumentException($"{Level} can't be lower than 0.");
        Level = level;
    }

    public int Level { get; }
}