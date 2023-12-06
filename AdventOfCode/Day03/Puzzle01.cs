namespace AdventOfCode.Day03;

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
        var map = PuzzleHelpers.GetMapFromFile(filepath);

        List<partNumber> possibleParts = new List<partNumber>();

        // Scan for part numbers
        for (var y = 0; y < map.Count; y++)
        {
            for (var x = 0; x < map[0].Count; x++)
            {
                var temp = map[y][x];
                if (temp == null) continue;
                if (Regex.Match(map[y][x], "[0-9]").Success)
                {
                    var partstring = new List<string>();
                    var startx=x;
                    var starty=y;
                    var fail_safe=0;
                    do
                    {
                        partstring.Add(map[y][x]);
                        x++;
                        fail_safe++;
                    } while (x<map.Count && Regex.Match(map[y][x], "[0-9]").Success && fail_safe<10 );
                    var finalStr = string.Join("",partstring);
                    int partNum = int.Parse(finalStr);
                    var part = new partNumber(partNum,startx,starty);
                    possibleParts.Add(part);
                }
            }
        }

        var finalsum = 0;
        foreach( var part in possibleParts){
            if(part.IsValidPart(map)){
                finalsum+=part.value;
            }
        }

        return finalsum;
    }
}