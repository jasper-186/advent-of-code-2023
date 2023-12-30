namespace AdventOfCode.Tests;

using AdventOfCode.Day08;
using Microsoft.Extensions.Logging;

public class Day08UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day08.Puzzle01.Input.Sample.txt");
        Assert.Equal(2, result);
    }

    [Fact]
    public void Puzzle01Sample02UnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day08.Puzzle01.Input.Sample02.txt");
        Assert.Equal(6, result);
    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day08.Puzzle.Input.txt");
        Assert.Equal(20093, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day08.Puzzle02.Input.Sample.txt");
        Assert.Equal(6, result);

    }

    [Fact]
    public void Puzzle02UnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day08.Puzzle.Input.txt");

        Assert.Equal(22103062509257, result);
    }
}