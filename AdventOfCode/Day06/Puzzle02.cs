using AdventOfCode.Common;
using Microsoft.Extensions.Logging;

namespace AdventOfCode.Day06;

public class Puzzle02 : PuzzleInterface
{
  private readonly ILogger _logger;

  public Puzzle02(ILoggerFactory loggerFactory)
  {
    _logger = loggerFactory.CreateLogger<Puzzle01>();
  }
  public long solve(string filepath)
  {
    var lines = FileUtils.ReadFileLines(filepath);
    if (lines.Count != 2)
    {
      throw new Exception("Not the right lines");
    }

    var times = lines[0].Replace(" ","").Split(":",StringSplitOptions.RemoveEmptyEntries);
    var distance = lines[1].Replace(" ","").Split(":",StringSplitOptions.RemoveEmptyEntries);

    var races = new List<Race>();
    for (int i = 1; i < times.Length; i++)
    {
      var r = new Race(long.Parse(times[i]), long.Parse(distance[i]));
      races.Add(r);
    }

    return races.Select(i=>(long)i.solve()).Aggregate((a, x) => a * x);
  }
}
