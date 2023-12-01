namespace AdventOfCode.Common;

public class FileUtils
{
  public static List<String> ReadFileLines(string filepath){
    return System.IO.File.ReadAllLines(filepath).ToList();
  }
}