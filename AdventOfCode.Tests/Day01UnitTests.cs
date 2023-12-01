namespace AdventOfCode.Tests;

using AdventOfCode.Day01;


public class Day01UnitTests:BaseUnitTests
{
    [Fact]
    public void Puzzle01UnitTest()
    {        
        var logger = Mock.Of<ILogger<Puzzle01>>();
        var puzzle=new Puzzle01(logger);
        var result = puzzle.solve(baseFilePath +"SampleInputs/Day01.Puzzle01.Input.Sample.txt");
        Assert.Equal(142, result);
    }
}