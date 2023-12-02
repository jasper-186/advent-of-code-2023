namespace AdventOfCode.Tests;

using AdventOfCode.Day01;
using Microsoft.Extensions.Logging;

public class Day01UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle01(loggerFactory);
            var result = puzzle.solve(baseFilePath + "SampleInputs/Day01.Puzzle01.Input.Sample.txt");
            Assert.Equal(142, result);
        
    }

    [Fact]
    public void Puzzle01PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle01(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day01.Puzzle01.Input.txt");
            Assert.Equal(54632, result);
    }

    [Fact]
    public void Puzzle02SampleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle02(loggerFactory);
            var result = puzzle.solve(baseFilePath + "SampleInputs/Day01.Puzzle02.Input.Sample.txt");
            Assert.Equal(281, result);        
    }    

    [Fact]
    public void Puzzle02PuzzleUnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle02(loggerFactory);
            var result = puzzle.solve(baseFilePath + "PuzzleInputs/Day01.Puzzle01.Input.txt");
            Assert.Equal(54019, result);        
    }    
}