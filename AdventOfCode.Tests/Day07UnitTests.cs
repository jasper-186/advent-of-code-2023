namespace AdventOfCode.Tests;

using AdventOfCode.Day07;
using Microsoft.Extensions.Logging;

public class Day07UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day07.Puzzle01.Input.Sample.txt");
        Assert.Equal(6440, result);

    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day07.Puzzle.Input.txt");
        Assert.Equal(252052080, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day07.Puzzle01.Input.Sample.txt");
        Assert.Equal(5905, result);

    }

    [Fact]
    public void Puzzle02UnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        var puzzle = new Puzzle02(loggerFactory);
        var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day07.Puzzle.Input.txt");

        Assert.Equal(252898370, result);
    }
}