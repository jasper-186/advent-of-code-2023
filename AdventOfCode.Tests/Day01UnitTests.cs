namespace AdventOfCode.Tests;

using AdventOfCode.Day01;
using Microsoft.Extensions.Logging;

public class Day01UnitTests : BaseUnitTests
{
    [Fact]
    public void Puzzle01UnitTest()
    {
        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            //var logger = Mock.Of<ILogger<Puzzle01>>();
            var puzzle = new Puzzle01(loggerFactory);
            var result = puzzle.solve(baseFilePath + "SampleInputs/Day01.Puzzle01.Input.Sample.txt");
            Assert.Equal(142, result);
        
    }
}