namespace AdventOfCode.Day07;

using System.Data;
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
    var hands = new List<Hand>();
    foreach (var line in lines)
    {
      var parts = line.Split(" ");
      var bid = int.Parse(parts[1]);
      var h = new Hand(parts[0], bid);
      hands.Add(h);
    }

    hands.Sort();
    var running_total = 0L;
    for (var rank = 0; rank < hands.Count; rank++)
    {
      var hand = hands[rank];
      var score = hand.getScore(rank + 1);
      _logger.LogInformation("hand {}, bid {}, rank {}, score {}", hand.cards, hand.bid,rank+1, score);
      running_total += score;
    }

    return running_total;
  }





  ////////////////////////////////////
}