using System.Text.RegularExpressions;
using AdventOfCode.Common;
namespace AdventOfCode.Day03;

public class PuzzleHelpers
{
    public static List<List<string>> GetMapFromFile(string fileName)
    {
        var map = new List<List<string>>();
        var lines = FileUtils.ReadFileLines(fileName);
        foreach (var line in lines)
        {
            var chars = line.ToCharArray().Select(i =>
            {
                if (i == '.')
                {
                    return "";
                }
                else
                {
                    return i.ToString();
                }
            });
            map.Add(chars.ToList());
        }
        return map;
    }
}

public class partNumber
{

    public int value { get; set; }
    public int startx { get; set; }
    public int starty { get; set; }

    public Tuple<int,int,string> partIdentifier{get;set;}

    public partNumber(int value, int startx, int starty)
    {
        this.value = value;
        this.startx = startx;
        this.starty = starty;
    }

    private int getValueLength()
    {
        var x = 1;
        if (value < x)
        {
            throw new Exception("Part number Cant be Negative");
        }
        var i = 1;
        do
        {
            x = x * 10;
            if (value < x)
            {
                return i;
            }
            i++;
        } while (i < 10);
        throw new Exception("Part number Cant be Negative");

    }

    public bool IsValidPart(List<List<string>> map)
    {
        // top left corner
        var tlCorner = new Tuple<int, int>(startx - 1, starty - 1);
        if (startx == 0)
        {
            tlCorner = new Tuple<int, int>(startx, tlCorner.Item2);
        }

        if (starty == 0)
        {
            tlCorner = new Tuple<int, int>(tlCorner.Item1, 0);
        }

        // bottom right corner
        var valueLength = getValueLength();
        var brCorner = new Tuple<int, int>(startx + valueLength + 1, starty + 2);

        if (brCorner.Item1 >= map.Count)
        {
            brCorner = new Tuple<int, int>(map.Count, brCorner.Item2);
        }

        if (brCorner.Item2 >= map[0].Count)
        {
            brCorner = new Tuple<int, int>(brCorner.Item1, map[0].Count);
        }

        for (var x = tlCorner.Item1; x < brCorner.Item1; x++)
        {
            // loop from the top left corner to top right corner
            for (var y = tlCorner.Item2; y < brCorner.Item2; y++)
            {
                if (map[y][x] == null)
                {
                    continue;
                }

                // any character that isnt a number, is a symbol, so its valid
                if (Regex.Match(map[y][x], "[^0-9]").Success)
                {
                    this.partIdentifier=new Tuple<int, int, string>(x,y,map[y][x]);
                    return true;
                }
            }
        }

        return false;
    }
}