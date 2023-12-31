namespace AdventOfCode.Day09;

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
        var runningTotal=0L;
        foreach(var line in lines){
            List<long> sequence = line.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(i=>long.Parse(i)).ToList();
            var temp = Sequence.GetNextInSequence(sequence);
            runningTotal+=temp;
        }
        return runningTotal;
    }
}