namespace AdventOfCode.Day08;

using System.Collections;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

public class HauntedNetwork
{
    public HauntedNetwork(string path)
    {
        this.path = path;
    }
    public Dictionary<string, HauntedNode> Network { get; private set; } = new Dictionary<string, HauntedNode>();
    public string path { get; private set; }

    public void AddNode(string key, HauntedNode node)
    {
        this.Network.Add(key, node);
    }

    public void ParseNode(string fileLine)
    {
        Regex rx = new Regex(@"([A-Z0-9]+)\s*=\s*\(([A-Z0-9]+),\s*([A-Z0-9]+)\)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);
        var m = rx.Match(fileLine);
        var groups = m.Groups;
        var node = new HauntedNode(groups[2].ToString().ToUpper(), groups[3].ToString().ToUpper());
        this.Network.Add(groups[1].ToString().ToUpper(), node);
    }

    public long TraversePath()
    {
        var current = "AAA";
        var index = 0;
        while (current != "ZZZ")
        {
            var path_ind = index % this.path.Length;
            var path_char = path[path_ind].ToString();
            current = Network[current][path_char];
            index++;
        }
        return index;
    }

    public long TraverseAllPath()
    {
        var current = Network.Keys.Where(i => i.EndsWith("A")).ToArray();
        var current_locations = new Dictionary<String, long>();

        foreach (var c in current)
        {
            var cu = c;
            var index = 0;
            while (!cu.EndsWith("Z"))
            {
                var path_ind = index % this.path.Length;
                var path_char = path[path_ind].ToString();
                cu = Network[cu][path_char];
                index++;
            }
            current_locations.Add(c, index);
        }

        // basically, we can find the distance each thing takes to walk from start to end, then find the Least Common multiple for whne those things overlap (since it loops)
        return lcm(current_locations.Values);
    }

    static long lcm(IEnumerable<long> list)
    {
        return list.Aggregate(lcm);
    }

    static long gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static long lcm(long a, long b)
    {
        return (a / gcf(a, b)) * b;
    }
}

public class HauntedNode
{
    public HauntedNode(string L, string R)
    {
        this.L = L;
        this.R = R;
    }
    public string L { get; private set; }
    public string R { get; private set; }

    public string this[string index]
    {
        get
        {
            switch (index.ToUpper())
            {
                case "R":
                    return this.R;
                case "L":
                    return this.L;
                default:
                    throw new IndexOutOfRangeException("Cannot index that String");
            }
        }

    }
}