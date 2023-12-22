namespace AdventOfCode.Tests;

using AdventOfCode.Day06;
using Microsoft.Extensions.Logging;

public class Day06UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day06.Puzzle01.Input.Sample.txt");
        Assert.Equal(288, result);

    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day06.Puzzle.Input.txt");
        Assert.Equal(219849, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day06.Puzzle01.Input.Sample.txt");
        Assert.Equal(71503, result);

    }

    [Fact]
    public void Puzzle02UnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day06.Puzzle.Input.txt");

        Assert.Equal(29432455, result);
    }
}