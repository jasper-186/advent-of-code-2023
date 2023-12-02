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

      var tensDigitString = "";
      for (int i = 0; i <= line.Length; i++)
      {
        var matches = Regex.Matches(line.Substring(0, i), string.Join("|", numberReplacements.Keys));
        if (matches.Any())
        {
          tensDigitString = matches.First().Value;
          break;
        }
      }

      var onesDigitString = "";
      for (int i = line.Length - 1; i >= 0; i--)
      {
        var substringLength = line.Length - i;

        if (substringLength < 0)
        {
          _logger.LogInformation($"{line} - {line.Length} - {i} = {substringLength}");
          _logger.LogInformation($"{line} has produced an invalid index - {substringLength}");
          throw new Exception("Something went wrong");
        }

        var substring = line.Substring(i, substringLength);
        var matches = Regex.Matches(substring, string.Join("|", numberReplacements.Keys));
        if (matches.Any())
        {
          onesDigitString = matches.First().Value;
          break;
        }
      }

      if (String.IsNullOrEmpty(tensDigitString) || string.IsNullOrEmpty(onesDigitString))
      {
        _logger.LogInformation($"{line} => Tens {tensDigitString} Ones {onesDigitString}");
        throw new Exception("Something went wrong");
      }

      if (numberReplacements.ContainsKey(tensDigitString))
      {
        tensDigitString = numberReplacements[tensDigitString];
      }

      var tensDigit = char.GetNumericValue(tensDigitString[0]) * 10;

      if (numberReplacements.ContainsKey(onesDigitString))
      {
        onesDigitString = numberReplacements[onesDigitString];
      }

      var onesDigit = char.GetNumericValue(onesDigitString[0]);
      var total = (long)(tensDigit + onesDigit);

      _logger.LogInformation($"{line} => {total}");
      var temp = runningTotal;
      runningTotal += total;
    }

    return runningTotal;
  }
}
