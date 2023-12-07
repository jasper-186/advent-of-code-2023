namespace AdventOfCode.Day05;

using AdventOfCode.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Day05Context : DbContext
{
    private SqliteConnection? _connection;
    public DbSet<Seed> Seeds { get; set; }
    public DbSet<SeedSoil> SeedSoils { get; set; }
    public DbSet<SoilFertilizer> SoilFertilizers { get; set; }
    public DbSet<FertilizerWater> FertilizerWaters { get; set; }
    public DbSet<WaterLight> WaterLights { get; set; }
    public DbSet<LightTemperature> LightTemperatures { get; set; }
    public DbSet<TemperatureHumidity> TemperatureHumiditys { get; set; }
    public DbSet<HumidityLocation> HumidityLocations { get; set; }

    public Day05Context()
    {

    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        options.UseSqlite(_connection);
    }

    public override void Dispose()
    {
        _connection?.Dispose();
        base.Dispose();
    }
}

public class Seed
{
    [Key]
    public long SeedId { get; set; }
}


public class SeedSoil
{
    [Key]
    public long SeedSoilId { get; set; }

    public long SeedLow { get; set; }
    public long SeedHigh { get; set; }

    public long SoilLow { get; set; }
    public long SoilHigh { get; set; }

}

public class SoilFertilizer
{
    [Key]
    public long SoilFertilizerId { get; set; }
    public long SoilLow { get; set; }
    public long SoilHigh { get; set; }
    public long FertilizerLow { get; set; }
    public long FertilizerHigh { get; set; }
}

public class FertilizerWater
{

    [Key]
    public long FertilizerWaterId { get; set; }
    public long FertilizerLow { get; set; }
    public long FertilizerHigh { get; set; }
    public long WaterLow { get; set; }
    public long WaterHigh { get; set; }

}


public class WaterLight
{
    [Key]
    public long WaterLightId { get; set; }
    public long WaterLow { get; set; }
    public long WaterHigh { get; set; }
    public long LightLow { get; set; }
    public long LightHigh { get; set; }

}

public class LightTemperature
{
    [Key]
    public long LightTemperatureId { get; set; }
    public long LightLow { get; set; }
    public long LightHigh { get; set; }
    public long TemperatureLow { get; set; }
    public long TemperatureHigh { get; set; }


}

public class TemperatureHumidity
{
    [Key]
    public long TemperatureHumidityId { get; set; }
    public long TemperatureLow { get; set; }
    public long TemperatureHigh { get; set; }
    public long HumidityLow { get; set; }
    public long HumidityHigh { get; set; }

}

public class HumidityLocation
{
    [Key]
    public long HumidityLocationId { get; set; }
    public long HumidityLow { get; set; }
    public long HumidityHigh { get; set; }
    public long LocationLow { get; set; }
    public long LocationHigh { get; set; }
}

public interface SeedParser{
    public abstract List<long> GetSeeds(string line);
}

public class Puzzle01SeedParser : SeedParser
{
    public List<long> GetSeeds(string line)
    {        
        var seedsId = line.Substring(6).Trim().Split(" ");
        return seedsId.Select(i=>long.Parse(i)).ToList();
    }
}

public class Puzzle02SeedParser : SeedParser
{
    public List<long> GetSeeds(string line)
    {
        throw new NotImplementedException();
    }
}
public static class DbHelper
{
    public static void Load(string filepath, SeedParser parser, Day05Context db)
    {
        var lineQueue = new Queue<String>(FileUtils.ReadFileLines(filepath));
        var seedsId = parser.GetSeeds(lineQueue.Dequeue());
        foreach (var sid in seedsId)
        {
            var t = new Seed()
            {
                SeedId = sid
            };
            db.Add(t);
        }
        db.SaveChanges();

        // ignore the blank seperating line
        lineQueue.Dequeue();


        // "seed-to-soil map:",
        var categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new SeedSoil()
            {
                SeedLow = srcStart,
                SeedHigh = srcStart + range,
                SoilLow = dstStart,
                SoilHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }
        db.SaveChanges();

        //"soil-to-fertilizer map:",
        categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new SoilFertilizer()
            {
                SoilLow = srcStart,
                SoilHigh = srcStart + range,
                FertilizerLow = dstStart,
                FertilizerHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }

        db.SaveChanges();

        //   "fertilizer-to-water map:",
        categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new FertilizerWater()
            {
                FertilizerLow = srcStart,
                FertilizerHigh = srcStart + range,
                WaterLow = dstStart,
                WaterHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }

        //   "water-to-light map:",
        categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new WaterLight()
            {
                WaterLow = srcStart,
                WaterHigh = srcStart + range,
                LightLow = dstStart,
                LightHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }

        //   "light-to-temperature map:",        
        categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new LightTemperature()
            {
                LightLow = srcStart,
                LightHigh = srcStart + range,
                TemperatureLow = dstStart,
                TemperatureHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }

        //   "temperature-to-humidity map:",
        categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new TemperatureHumidity()
            {
                TemperatureLow = srcStart,
                TemperatureHigh = srcStart + range,
                HumidityLow = dstStart,
                HumidityHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }

        //   "humidity-to-location map:",
        categoryHeader = lineQueue.Dequeue();
        while (lineQueue.TryDequeue(out var mapLine) && !String.IsNullOrWhiteSpace(mapLine))
        {
            var parts = mapLine.Split(" ");
            var dstStart = long.Parse(parts[0]);
            var srcStart = long.Parse(parts[1]);
            var range = long.Parse(parts[2]);
            var newSeedSoil = new HumidityLocation()
            {
                HumidityLow = srcStart,
                HumidityHigh = srcStart + range,
                LocationLow = dstStart,
                LocationHigh = dstStart + range,
            };
            db.Add(newSeedSoil);
        }

        db.SaveChanges();
    }

    public static long getMappedSoilId(long seedId, Day05Context db)
    {
        // "seed-to-soil map:",
        var soil = db.SeedSoils.Where(i => i.SeedLow < seedId && i.SeedHigh > seedId).FirstOrDefault();
        // if the soil is not mapped, add the mapping
        if (soil == null)
        {
            soil = new SeedSoil()
            {
                SeedLow = seedId,
                SeedHigh = seedId,
                SoilLow = seedId,
                SoilHigh = seedId,
            };
            db.Add(soil);
            db.SaveChanges();
        }

        var temp = seedId - soil.SeedLow;
        var soilId = soil.SoilLow + temp;
        return soilId;
    }

    public static long getMappedFertilizerId(long soilId, Day05Context db)
    {
        //"soil-to-fertilizer map:",
        var fertilizer = db.SoilFertilizers.Where(i => i.SoilLow < soilId && i.SoilHigh > soilId).FirstOrDefault();

        // if the soil is not mapped, add the mapping
        if (fertilizer == null)
        {
            fertilizer = new SoilFertilizer()
            {
                FertilizerLow = soilId,
                FertilizerHigh = soilId,
                SoilLow = soilId,
                SoilHigh = soilId,
            };
            db.Add(fertilizer);
            db.SaveChanges();
        }

        var temp = soilId - fertilizer.SoilLow;
        var fertilizerId = fertilizer.FertilizerLow + temp;
        return fertilizerId;
    }

    public static long getMappedWaterId(long fertilizerId, Day05Context db)
    {
        //   "fertilizer-to-water map:",
        var water = db.FertilizerWaters.Where(i => i.FertilizerLow < fertilizerId && i.FertilizerHigh > fertilizerId).FirstOrDefault();

        // if the soil is not mapped, add the mapping
        if (water == null)
        {
            water = new FertilizerWater()
            {
                FertilizerLow = fertilizerId,
                FertilizerHigh = fertilizerId,
                WaterLow = fertilizerId,
                WaterHigh = fertilizerId,
            };
            db.Add(water);
            db.SaveChanges();
        }

        var temp = fertilizerId - water.FertilizerLow;
        var waterId = water.WaterLow + temp;
        return waterId;
    }

    public static long getMappedLightId(long waterId, Day05Context db)
    {
        //   "water-to-light map:",
        var light = db.WaterLights.Where(i => i.WaterLow < waterId && i.WaterHigh > waterId).FirstOrDefault();

        // if the soil is not mapped, add the mapping
        if (light == null)
        {
            light = new WaterLight()
            {
                LightLow = waterId,
                LightHigh = waterId,
                WaterLow = waterId,
                WaterHigh = waterId,
            };
            db.Add(light);
            db.SaveChanges();
        }

        var temp = waterId - light.WaterLow;
        var lightId = light.LightLow + temp;
        return lightId;
    }

    public static long getMappedTemperatureId(long lightId, Day05Context db)
    {
        //   "water-to-light map:",
        var temperature = db.LightTemperatures.Where(i => i.LightLow < lightId && i.LightHigh > lightId).FirstOrDefault();

        // if the soil is not mapped, add the mapping
        if (temperature == null)
        {
            temperature = new LightTemperature()
            {
                LightLow = lightId,
                LightHigh = lightId,
                TemperatureLow = lightId,
                TemperatureHigh = lightId,
            };
            db.Add(temperature);
            db.SaveChanges();
        }

        var temp = lightId - temperature.LightLow;
        var temperatureId = temperature.TemperatureLow + temp;
        return temperatureId;
    }

    public static long getMappedHumidityId(long temperatureId, Day05Context db)
    {
        //   "water-to-light map:",
        var humidity = db.TemperatureHumiditys.Where(i => i.TemperatureLow < temperatureId && i.TemperatureHigh > temperatureId).FirstOrDefault();

        // if the soil is not mapped, add the mapping
        if (humidity == null)
        {
            humidity = new TemperatureHumidity()
            {
                HumidityLow = temperatureId,
                HumidityHigh = temperatureId,
                TemperatureLow = temperatureId,
                TemperatureHigh = temperatureId,
            };
            db.Add(humidity);
            db.SaveChanges();
        }

        var temp = temperatureId - humidity.TemperatureLow;
        var humidityId = humidity.HumidityLow + temp;
        return humidityId;
    }

    public static long getMappedLocationId(long humidityId, Day05Context db)
    {
        //   "water-to-light map:",
        var location = db.HumidityLocations.Where(i => i.HumidityLow < humidityId && i.HumidityHigh > humidityId).FirstOrDefault();

        // if the soil is not mapped, add the mapping
        if (location == null)
        {
            location = new HumidityLocation()
            {
                HumidityLow = humidityId,
                HumidityHigh = humidityId,
                LocationLow = humidityId,
                LocationHigh = humidityId,
            };
            db.Add(location);
            db.SaveChanges();
        }

        var temp = humidityId - location.HumidityLow;
        var locationId = location.LocationLow + temp;
        return locationId;
    }

}