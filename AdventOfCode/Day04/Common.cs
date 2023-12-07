using System.Text.RegularExpressions;
using AdventOfCode.Common;
namespace AdventOfCode.Day04;

public class ScratchCard
{
    public int id { get; private set; }
    public SortedSet<int> winningNumbers { get; set; } = new SortedSet<int>();
    public SortedSet<int> cardNumbers { get; set; } = new SortedSet<int>();

    public ScratchCard(string line)
    {
        var match = Regex.Match(line, "Card +([0-9]+):( +([0-9]+))+ \\|( +([0-9]+))+");
        if (match.Success)
        {
            this.id = int.Parse(match.Groups[1].Value);
            foreach (var w in match.Groups[3].Captures)
            {
                var wi = int.Parse(w.ToString());
                winningNumbers.Add(wi);
            }

            foreach (var w in match.Groups[5].Captures)
            {
                var wi = int.Parse(w.ToString());
                cardNumbers.Add(wi);
            }
        }
    }

    public int getScore()
    {
        var winning = winningNumbers.Intersect(cardNumbers);
        if (winning.Count() == 0)
        {
            return 0;
        }
        var power = winning.Count() - 1;
        return (int)Math.Pow(2, power);
    }
    public List<int> getWinningNumbers()
    {
        return winningNumbers.Intersect(cardNumbers).ToList();       
    }
}