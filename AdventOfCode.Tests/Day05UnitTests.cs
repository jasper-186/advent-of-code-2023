namespace AdventOfCode.Tests;

using AdventOfCode.Day05;
using Microsoft.Extensions.Logging;

public class Day05UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

        //var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle = new Puzzle01(loggerFactory);
        var result = puzzle.solve(baseFilePath + "SampleInputs/Day05.Puzzle01.Input.Sample.txt");
        Assert.Equal(35, result);

    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var puzzle = new Puzzle01(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day05.Puzzle.Input.txt");
            Assert.Equal(910845529, result);
    }

    // [Fact]
    // public void Puzzle02SampleUnitTest()
    // {
    //     using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

    //         //var logger = Mock.Of<ILogger<Puzzle01>>();
    //         var puzzle = new Puzzle02(loggerFactory);
    //         var result = puzzle.solve(baseFilePath + "SampleInputs/Day04.Puzzle01.Input.Sample.txt");
    //         Assert.Equal(30, result);        
    // }    

    // [Fact]
    // public void Puzzle02PuzzleUnitTest()
    // {
    //     using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

    //         //var logger = Mock.Of<ILogger<Puzzle01>>();
    //         var puzzle = new Puzzle02(loggerFactory);
    //         var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day04.Puzzle.Input.txt");
    //         Assert.Equal(14624680, result);        
    // }    
}