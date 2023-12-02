namespace AdventOfCode.Day01;
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

    var runningTotal = 0L;

    // i have a feeling that i'll need to parse the line into Chars for part 2 so
   
    foreach (var line in lines)
    {
      if(line.Length==0) continue;
      _logger.LogInformation("Processing line {line}",line);
      Nullable<char> firstDigit = null;
      Nullable<char> lastDigit = null;

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

      // if(firstDigit==null || lastDigit == null){
      //   _logger.LogError("Failed to find digits in line {line}",line);
      //     break;
      // }
      _logger.LogInformation("Found digits {firstDigit},{lastDigit},",firstDigit,lastDigit);
      var tensDigit = char.GetNumericValue(firstDigit.GetValueOrDefault('0'))*10;
      var digit = char.GetNumericValue(lastDigit.GetValueOrDefault('0'));
      var total = (long)(tensDigit+digit);
      _logger.LogInformation("Digits combine to {total}",total);
      runningTotal =runningTotal+ total;      
      _logger.LogInformation("runningTotal {runningTotal}",runningTotal);
      
    }
    return runningTotal;
  }
}
