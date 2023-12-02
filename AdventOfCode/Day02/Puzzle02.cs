namespace AdventOfCode.Day02;

using System.Data;
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
    var bag = new CubeBag(12, 13, 14);
    var games = FileUtils.ReadFileLines(filepath);
    var allGames = new List<Game>();
    foreach(var gameStr in games){
      // get game number,
      var lineparts = gameStr.Split(":");
      var numStr = lineparts[0].Substring(5);
      var num = int.Parse(numStr);
      var game = new Game(num);
      foreach(var pullStr in lineparts[1].Split(";")){
        var pull = new Dictionary<string,int>();
        foreach(var rockStr in pullStr.Split(", ")){
          // expecting rockStr to be "45 blue"
         
          var parts = rockStr.Trim().Split(" ");
          var intNum=int.Parse(parts[0]);
          pull[parts[1]]=intNum;
        }
         
        if(!pull.ContainsKey("red")){
          pull["red"]=0;
        }
        if(!pull.ContainsKey("blue")){
          pull["blue"]=0;
        }
        if(!pull.ContainsKey("green")){
          pull["green"]=0;
        }        
        game.addPull(pull["red"],pull["green"],pull["blue"]);
      }
      allGames.Add(game);
    }

    var result = allGames.Where(bag.isValid).Select(g=>g.id).Sum();
    return result;
  }


}
