namespace AdventOfCode.Day11;

using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using AdventOfCode.Common;

public class ImageField
{
    public char[,] field { get; private set; }
    public Tuple<long, long>? starting_point { get; private set; }

    public ImageField(List<string> filelines)
    {
        var temp = filelines.First();
        field = new Pipe[filelines.Count, temp.Length];
        for (int y = 0; y < filelines.Count; y++)
        {
            var line = filelines[y];
            for (int x = 0; x < line.Length; x++)
            {
                var c = line[x].ToString();
                if (c == "S")
                {
                    starting_point = new Tuple<long, long>(y, x);
                }
                field[y, x] = new Pipe(c, x, y);
            }
        }
    }

    public long Traverse()
    {
        var pipesQueue = new Queue<Pipe>();

        // From the starting point, get neighbors
        var s = field[starting_point.Item1, starting_point.Item2];
        s.Traverse(0);
        pipesQueue.Enqueue(s);
        while (pipesQueue.TryDequeue(out Pipe? current))
        {
            if (current == null) continue;
            var n = current.getNeighbors(field);
            foreach (var p in n)
            {
                long d = current.distance.Value + 1;
                if (!p.distance.HasValue || d < p.distance)
                {
                    p.Traverse(d);
                    pipesQueue.Enqueue(p);
                }
            }
        }

        var max_distance = -1L;
        var length = field.GetLength(0);
        var width = field.GetLength(1);
        for (var j = 0; j < length; j++)
        {
            for (var i = 0; i < width; i++)
            {
                if (field[j, i].distance.HasValue && field[j, i].distance > max_distance)
                {
                    max_distance = field[j, i].distance.Value;
                }
            }
        }
        return max_distance;
    }
}

public class Pipe : IEquatable<Pipe>, IComparable<Pipe>
{
    public string ogChar { get; private set; }
    public long x { get; private set; }
    public long y { get; private set; }
    public long? distance { get; private set; }

    public Pipe(string c, long x, long y)
    {
        this.ogChar = c;
        this.x = x;
        this.y = y;
    }

    public void Traverse(long distance)
    {
        // dirt cant have distance
        if (this.ogChar == ".") return;
        if (this.distance == null)
        {
            this.distance = distance;
        }

        if (distance < this.distance)
        {
            this.distance = distance;
        }
    }

    public List<Pipe> getNeighbors(Pipe[,] map)
    {
        var neighbors = new List<Pipe>();
        Pipe? n_neighbor = null;
        Pipe? e_neighbor = null;
        Pipe? s_neighbor = null;
        Pipe? w_neighbor = null;
        var length = map.GetLength(0);
        var width = map.GetLength(1);
        if (y > 0)
        {
            n_neighbor = map[y - 1, x];
        }
        if (x < (width - 1))
        {
            e_neighbor = map[y, x + 1];
        }
        if (y < (length - 1))
        {
            s_neighbor = map[y + 1, x];
        }
        if (x > 0)
        {
            w_neighbor = map[y, x - 1];
        }

        switch (ogChar)
        {
            case ".":
                break;
            case "|": // is a vertical pipe connecting north and south.
                if (n_neighbor != null) neighbors.Add(n_neighbor);
                if (s_neighbor != null) neighbors.Add(s_neighbor);
                break;
            case "-": // is a horizontal pipe connecting east and west.
                if (e_neighbor != null) neighbors.Add(e_neighbor);
                if (w_neighbor != null) neighbors.Add(w_neighbor);
                break;
            case "L": // is a 90-degree bend connecting north and east.
                if (n_neighbor != null) neighbors.Add(n_neighbor);
                if (e_neighbor != null) neighbors.Add(e_neighbor);
                break;
            case "J": // is a 90-degree bend connecting north and west.
                if (n_neighbor != null) neighbors.Add(n_neighbor);
                if (w_neighbor != null) neighbors.Add(w_neighbor);
                break;
            case "7": // is a 90-degree bend connecting south and west.
                if (s_neighbor != null) neighbors.Add(s_neighbor);
                if (w_neighbor != null) neighbors.Add(w_neighbor);
                break;
            case "F": // is a 90-degree bend connecting south and east.
                if (e_neighbor != null) neighbors.Add(e_neighbor);
                if (s_neighbor != null) neighbors.Add(s_neighbor);
                break;
            case "S":
                // this is the starting point, which is Guarenteed to have 2 nieghbors that ALSO connect back to this node
                if (n_neighbor != null && n_neighbor.getNeighbors(map).Contains(this))
                {
                    neighbors.Add(n_neighbor);
                }

                if (e_neighbor != null && e_neighbor.getNeighbors(map).Contains(this))
                {
                    neighbors.Add(e_neighbor);
                }

                if (s_neighbor != null && s_neighbor.getNeighbors(map).Contains(this))
                {
                    neighbors.Add(s_neighbor);
                }

                if (w_neighbor != null && w_neighbor.getNeighbors(map).Contains(this))
                {
                    neighbors.Add(w_neighbor);
                }
                break;
        }
        return neighbors;
    }

    public bool Equals(Pipe? other)
    {
        if (this.x == other?.x && this.y == other?.y) return true;

        return false;
    }

    public int CompareTo(Pipe? other)
    {
        // If other is not a valid object reference, this instance is greater.
        if (other == null) return 1;

        // check y first, as its the first dimentsion
        var y_com = this.y.CompareTo(other.y);
        if (y_com != 0)
        {
            return y_com;
        }

        // if we're on the same line then compare x
        return this.x.CompareTo(other.x);
    }
}