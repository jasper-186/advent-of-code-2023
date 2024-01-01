namespace AdventOfCode.Day10;

using AdventOfCode.Common;
using Microsoft.Extensions.Logging;

public class Puzzle01 : PuzzleInterface
{
    private readonly ILogger _logger;

    public Puzzle01(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Puzzle01>();
    }

    public long solve(string filepath)
    {
        var lines = FileUtils.ReadFileLines(filepath);
       var pf = new PipeField(lines);
       return pf.Traverse();
    }
}