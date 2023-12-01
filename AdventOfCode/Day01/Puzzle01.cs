namespace AdventOfCode.Day01;
using AdventOfCode.Common;
using Microsoft.Extensions.Logging;

public class Puzzle01 : PuzzleInterface
{
   private readonly ILogger _logger;

    public Puzzle01(ILogger<Puzzle01> logger)
    {
        _logger = logger;
    }

  public long solve(string filepath)
  {
    var lines = FileUtils.ReadFileLines(filepath);

    var runningTotal = 0L;

    // i have a feeling that i'll need to parse the line into Chars for part 2 so
    Nullable<char> firstDigit = null;
    Nullable<char> lastDigit = null;

    foreach (var line in lines)
    {
      foreach (char i in line)
      {
        if (char.IsDigit(i))
        {
          if (firstDigit == null)
          {
            firstDigit = i;
          }
          lastDigit = i;
        }
      }

      var tensDigit = char.GetNumericValue(firstDigit.GetValueOrDefault('0'))*10;
      var digit = char.GetNumericValue(lastDigit.GetValueOrDefault('0'));
      var total = (long)(tensDigit+digit);
      var temp = runningTotal;
      runningTotal += total;
      

    }
    return runningTotal;
  }
}
