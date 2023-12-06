namespace AdventOfCode.Tests;

using AdventOfCode.Day03;
using Microsoft.Extensions.Logging;

public class Day03UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day03.Puzzle01.Input.Sample.txt");
        Assert.Equal(4361, result);

    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var puzzle = new Puzzle01(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day03.Puzzle.Input.txt");
            Assert.Equal(531561, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle02(loggerFactory);
            var result = puzzle.solve(baseFilePath + "SampleInputs/Day03.Puzzle01.Input.Sample.txt");
            Assert.Equal(467835, result);        
    }    

    [Fact]
    public void Puzzle02PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle02(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day03.Puzzle.Input.txt");
            Assert.Equal(83279367, result);        
    }    
}