namespace AdventOfCode.Day04;

using System.Data;
using System.Text.RegularExpressions;
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
        var runningTotal = 0;
        var lines = System.IO.File.ReadAllLines(filepath);
        foreach (var line in lines)
        {
            var sc = new ScratchCard(line);
            runningTotal += sc.getScore();
        }

        return runningTotal;
    }
}