namespace AdventOfCode.Tests;

using AdventOfCode.Day09;
using Microsoft.Extensions.Logging;

public class Day09UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day09.Puzzle01.Input.Sample.txt");
        Assert.Equal(114, result);
    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day09.Puzzle.Input.txt");
        Assert.Equal(1584748274, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day09.Puzzle01.Input.Sample.txt");
        Assert.Equal(2, result);

    }

    [Fact]
    public void Puzzle02UnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day09.Puzzle.Input.txt");

        Assert.Equal(1026, result);
    }
}