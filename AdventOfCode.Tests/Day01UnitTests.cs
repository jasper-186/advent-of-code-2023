namespace AdventOfCode.Tests;

using AdventOfCode.Day01;

public class Day01UnitTests:BaseUnitTests
{
    [Fact]
    public void Puzzle01UnitTest()
    {        
        var result = Puzzle01.solve(baseFilePath +"SampleInputs/Day01.Puzzle01.Input.Sample.txt");
        Assert.Equal(142, result);
    }
}