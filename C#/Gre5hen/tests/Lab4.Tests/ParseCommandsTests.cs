using Itmo.ObjectOrientedProgramming.Lab4.ResultTypes;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParseCommandsTests
{
    [Fact]
    public void ParseShouldReturnAllSuccess()
    {
        var parser = new Parser.Parser();

        Assert.True(parser.Parse("connect C:\\test -m local") is HandleResult.Success);
        Assert.True(parser.Parse("tree goto Lab2") is HandleResult.Success);
        Assert.True(parser.Parse("file delete text.txt") is HandleResult.Success);
        Assert.True(parser.Parse("tree list -d 3") is HandleResult.Success);
        Assert.True(parser.Parse("tree list") is HandleResult.Success);
    }

    [Fact]
    public void ParseShouldReturnAllFail()
    {
        var parser = new Parser.Parser();

        Assert.True(parser.Parse("connect C:\\test -auf local") is HandleResult.Fail);
        Assert.True(parser.Parse("tree unknown Lab2") is HandleResult.Fail);
        Assert.True(parser.Parse("file check text.txt") is HandleResult.Fail);
        Assert.True(parser.Parse("tree -d 3") is HandleResult.Fail);
        Assert.True(parser.Parse("genious") is HandleResult.Fail);
    }
}