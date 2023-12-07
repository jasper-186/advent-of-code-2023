namespace AdventOfCode.Day04;

using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using AdventOfCode.Common;
using Microsoft.Extensions.Logging;

public class Puzzle02 : PuzzleInterface
{
    private readonly ILogger _logger;

    public Puzzle02(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<Puzzle01>();
    }

    public long solve(string filepath)
    {
        var lines = System.IO.File.ReadAllLines(filepath);
        var scorecards = new Dictionary<int, ScratchCard>();
        var scratchCardsToProcess = new Queue<ScratchCard>();
        foreach (var line in lines)
        {
            var sc = new ScratchCard(line);
            scorecards[sc.id] = sc;
            scratchCardsToProcess.Enqueue(sc);
        }

        var totalScratchCards = 0;
        while (scratchCardsToProcess.TryDequeue(out var scratchCard))
        {
            totalScratchCards++;
            var winningNumbers = scratchCard.getWinningNumbers();
            for (int i = 1; i <= winningNumbers.Count(); i++)
            {
                var id = i + scratchCard.id;
                if(scorecards.ContainsKey(id)){
                    scratchCardsToProcess.Enqueue(scorecards[id]);
                }
            }
        }

        return totalScratchCards;
    }
}