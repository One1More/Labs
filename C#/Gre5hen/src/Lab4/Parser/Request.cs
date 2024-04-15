using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser;

public class Request
{
    private int _relativeInd;
    public Request(string info)
    {
        Info = info.Split(' ').ToList();
        Length = Info.Count;
        _relativeInd = -1;
    }

    public int Length { get; }
    private IReadOnlyList<string> Info { get; }

    public string Next()
    {
        if (_relativeInd + 1 < Length)
        {
            _relativeInd++;

            return Info[_relativeInd];
        }

        return string.Empty;
    }

    public bool CompareNext(string keyWord)
    {
        if (_relativeInd + 1 < Length)
        {
            if (keyWord == Info[_relativeInd + 1])
            {
                _relativeInd++;

                return true;
            }
        }

        return false;
    }
}