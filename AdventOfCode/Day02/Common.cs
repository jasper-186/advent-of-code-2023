namespace AdventOfCode.Day02;

public class Game
{
  public int id;
  // Pulls in RGB order
  public List<Tuple<int, int, int>> pulls = new List<Tuple<int, int, int>>();

  public Game(int id)
  {
    this.id = id;
  }

  public void addPull(int r, int g, int b)
  {
    pulls.Add(new Tuple<int, int, int>(r, g, b));
  }

  public long getPower(){
    var redPower = pulls.Select(i=>i.Item1).Max();
    var greenPower = pulls.Select(i=>i.Item2).Max();
    var bluePower = pulls.Select(i=>i.Item3).Max();

    return redPower*greenPower*bluePower;
  }
}

public class CubeBag
{
  int red;
  int blue;
  int green;

  public CubeBag(int red, int green, int blue)
  {
    this.red = red;
    this.blue = blue;
    this.green = green;
  }

  public bool isValid(Game game)
  {

    // Pulls are in RGB order
    foreach (var pull in game.pulls)
    {
      if (pull.Item1 > this.red) return false;
      if (pull.Item2 > this.green) return false;
      if (pull.Item3 > this.blue) return false;
    }

    return true;
  }

  
}