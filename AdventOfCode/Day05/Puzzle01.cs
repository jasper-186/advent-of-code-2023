namespace AdventOfCode.Day05;

using System.Data;
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
    using (var db = new Day05Context())
    {
      db.Database.EnsureCreated();
      // Load the Database if it hasn't yet been loaded
      if (db.HumidityLocations.Count() < 1)
      {
        var parser = new Puzzle01SeedParser();
        DbHelper.Load(filepath, parser, db);
      }

      long lowestLocation = int.MaxValue;
      foreach (var seed in db.Seeds)
      {
        var soilId = DbHelper.getMappedSoilId(seed.SeedId, db);
        var fertilizerId = DbHelper.getMappedFertilizerId(soilId, db);
        var waterId = DbHelper.getMappedWaterId(fertilizerId, db);
        var lightId = DbHelper.getMappedLightId(waterId, db);
        var temperatureId = DbHelper.getMappedTemperatureId(lightId, db);
        var humidityId = DbHelper.getMappedHumidityId(temperatureId, db);
        var locationId = DbHelper.getMappedLocationId(humidityId, db);
        if (locationId < lowestLocation)
        {
          lowestLocation = locationId;
        }
      }

      //db.Database.EnsureDeleted();
      return lowestLocation;
    }
  }





  ////////////////////////////////////
}