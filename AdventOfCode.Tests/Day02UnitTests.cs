namespace AdventOfCode.Tests;

using AdventOfCode.Day02;
using Microsoft.Extensions.Logging;

public class Day02UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day02.Puzzle01.Input.Sample.txt");
        Assert.Equal(8, result);

    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var puzzle = new Puzzle01(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day02.Puzzle.Input.txt");
            Assert.Equal(2149, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle02(loggerFactory);
            var result = puzzle.solve(baseFilePath + "SampleInputs/Day02.Puzzle01.Input.Sample.txt");
            Assert.Equal(2286, result);        
    }    

    [Fact]
    public void Puzzle02PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle02(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day02.Puzzle.Input.txt");
            Assert.Equal(71274, result);        
    }    
}