namespace AdventOfCode.Day05;

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
    using (var db = new Day05Context())
    {
      db.Database.EnsureCreated();
      // Load the Database if it hasn't yet been loaded
      if (db.HumidityLocations.Count() < 1)
      {
        var parser = new Puzzle02SeedParser();
        DbHelper.Load(filepath, parser, db);
      }

      // Seeds can't be loaded via a database parser due to size
      var lineQueue = new Queue<String>(FileUtils.ReadFileLines(filepath));
      var seedRanges = lineQueue.Dequeue();
      lineQueue = null;
      var seedQueue = new Queue<string>(seedRanges.Substring(6).Trim().Split(" "));

      long lowestLocation = int.MaxValue;
      object locationLock = new object();

      while (seedQueue.Count() > 0)
      {
        var seedStartRange = long.Parse(seedQueue.Dequeue());
        var seedRangeLength = long.Parse(seedQueue.Dequeue());
        var seedEndRange = seedStartRange + seedRangeLength;
        Parallel.For(seedStartRange, seedEndRange, new ParallelOptions() { MaxDegreeOfParallelism = 4 }, s =>
        {
          var dbp = new Day05Context();
          var locationId = GetSeedLocation(s, dbp);
          // is the one i have lower?
          if (locationId < lowestLocation)
          {
            // Grab the lock
            lock (locationLock)
            {
              // Is it Still lower after grabbing the lock?
              if (locationId < lowestLocation)
              {
                lowestLocation = locationId;
              }
            }
          }
        });
      }

      //db.Database.EnsureDeleted();
      return lowestLocation;
    }

  }

  public long GetSeedLocation(long seedId, Day05Context db)
  {
    _logger.LogTrace($"Seed Id: {seedId}");
    var soilId = DbHelper.getMappedSoilId(seedId, db);
    _logger.LogTrace($"Soil Id: {soilId}");
    var fertilizerId = DbHelper.getMappedFertilizerId(soilId, db);
    _logger.LogTrace($"Fertilizer Id: {fertilizerId}");
    var waterId = DbHelper.getMappedWaterId(fertilizerId, db);
    _logger.LogTrace($"Water Id: {waterId}");
    var lightId = DbHelper.getMappedLightId(waterId, db);
    _logger.LogTrace($"Light Id: {lightId}");
    var temperatureId = DbHelper.getMappedTemperatureId(lightId, db);
    _logger.LogTrace($"Temperature Id: {temperatureId}");
    var humidityId = DbHelper.getMappedHumidityId(temperatureId, db);
    _logger.LogTrace($"Humidity Id: {humidityId}");
    var locationId = DbHelper.getMappedLocationId(humidityId, db);

    _logger.LogTrace($"Location Id: {locationId}");

    return locationId;
  }
}



