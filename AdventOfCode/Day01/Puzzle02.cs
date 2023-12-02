namespace AdventOfCode.Day01;

using System.Text.RegularExpressions;
using AdventOfCode.Common;
using Microsoft.Extensions.Logging;

public class Puzzle02 : PuzzleInterface
{
  private readonly ILogger _logger;

  public Puzzle02(ILoggerFactory loggerFactory)
  {
    _logger = loggerFactory.CreateLogger<Puzzle02>();
  }

  public long solve(string filepath)
  {
    var lines = FileUtils.ReadFileLines(filepath);

    var runningTotal = 0L;

    // i have a feeling that i'll need to parse the line into Chars for part 2 so

    foreach (var line in lines)
    {
      // before we process the line, we need to replace the numbers("nine") with numbers("9")

      var numberReplacements = new Dictionary<string, string> {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
        { "[0-9]", "0" }
      };


      var matches = Regex.Matches(line, string.Join("|", numberReplacements.Keys));
      string digit;
      string match = matches.First().Value;


      if (numberReplacements.ContainsKey(match))
      {
        digit = numberReplacements[match];
      }
      else
      {
        digit = match;
      }
      var tensDigit = char.GetNumericValue(digit[0]) * 10;

      match = matches.Last().Value;
      if (numberReplacements.ContainsKey(match))
      {
        digit = numberReplacements[match];
      }
      else
      {
        digit = match;
      }
      var onesDigit = char.GetNumericValue(digit[0]);
      var total = (long)(tensDigit + onesDigit);

      _logger.LogInformation($"{line} => {total}");
      var temp = runningTotal;
      runningTotal += total;
    }
    return runningTotal;
  }
}
