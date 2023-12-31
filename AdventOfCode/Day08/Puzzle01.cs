namespace AdventOfCode.Day08;

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
        var lines = new Queue<String>(FileUtils.ReadFileLines(filepath));
        // Path
        var network = new HauntedNetwork(lines.Dequeue());
        
        while(lines.TryDequeue(out string? line)){
            if(String.IsNullOrWhiteSpace(line)){
                continue;
            }
        
            network.ParseNode(line); 
        }

        return network.TraversePath();
    }
}