namespace AdventOfCode.Program;
using Microsoft.Extensions.Logging;
class Program
{
    static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Advent of Code 2023!");

        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var baseDir = "/home/joe/Enlistments/advent-of-code-2023/";
        // Day 01s
        var Day_01_01 = new AdventOfCode.Day01.Puzzle02(loggerFactory);
        var result = Day_01_01.solve(baseDir + "PuzzleInputs/Day01.Puzzle01.Input.txt");
        // 53998 is too low
        Console.WriteLine($"Day 01 Puzzle 02 - {result}");
        var _logger = loggerFactory.CreateLogger<Program>();
        _logger.LogInformation("Advent of Code Result: {result}",result);

    }
}
