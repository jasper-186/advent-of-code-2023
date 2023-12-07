using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdventOfCode.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FertilizerWaters",
                columns: table => new
                {
                    FertilizerWaterId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FertilizerLow = table.Column<long>(type: "INTEGER", nullable: false),
                    FertilizerHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    WaterLow = table.Column<long>(type: "INTEGER", nullable: false),
                    WaterHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerWaters", x => x.FertilizerWaterId);
                });

            migrationBuilder.CreateTable(
                name: "HumidityLocations",
                columns: table => new
                {
                    HumidityLocationId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HumidityLow = table.Column<long>(type: "INTEGER", nullable: false),
                    HumidityHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    LocationLow = table.Column<long>(type: "INTEGER", nullable: false),
                    LocationHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumidityLocations", x => x.HumidityLocationId);
                });

            migrationBuilder.CreateTable(
                name: "LightTemperatures",
                columns: table => new
                {
                    LightTemperatureId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LightLow = table.Column<long>(type: "INTEGER", nullable: false),
                    LightHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    TemperatureLow = table.Column<long>(type: "INTEGER", nullable: false),
                    TemperatureHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightTemperatures", x => x.LightTemperatureId);
                });

            migrationBuilder.CreateTable(
                name: "Seeds",
                columns: table => new
                {
                    SeedId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.SeedId);
                });

            migrationBuilder.CreateTable(
                name: "SeedSoils",
                columns: table => new
                {
                    SeedSoilId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SeedLow = table.Column<long>(type: "INTEGER", nullable: false),
                    SeedHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    SoilLow = table.Column<long>(type: "INTEGER", nullable: false),
                    SoilHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedSoils", x => x.SeedSoilId);
                });

            migrationBuilder.CreateTable(
                name: "SoilFertilizers",
                columns: table => new
                {
                    SoilFertilizerId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SoilLow = table.Column<long>(type: "INTEGER", nullable: false),
                    SoilHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    FertilizerLow = table.Column<long>(type: "INTEGER", nullable: false),
                    FertilizerHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoilFertilizers", x => x.SoilFertilizerId);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureHumiditys",
                columns: table => new
                {
                    TemperatureHumidityId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemperatureLow = table.Column<long>(type: "INTEGER", nullable: false),
                    TemperatureHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    HumidityLow = table.Column<long>(type: "INTEGER", nullable: false),
                    HumidityHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureHumiditys", x => x.TemperatureHumidityId);
                });

            migrationBuilder.CreateTable(
                name: "WaterLights",
                columns: table => new
                {
                    WaterLightId = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WaterLow = table.Column<long>(type: "INTEGER", nullable: false),
                    WaterHigh = table.Column<long>(type: "INTEGER", nullable: false),
                    LightLow = table.Column<long>(type: "INTEGER", nullable: false),
                    LightHigh = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterLights", x => x.WaterLightId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizerWaters");

            migrationBuilder.DropTable(
                name: "HumidityLocations");

            migrationBuilder.DropTable(
                name: "LightTemperatures");

            migrationBuilder.DropTable(
                name: "Seeds");

            migrationBuilder.DropTable(
                name: "SeedSoils");

            migrationBuilder.DropTable(
                name: "SoilFertilizers");

            migrationBuilder.DropTable(
                name: "TemperatureHumiditys");

            migrationBuilder.DropTable(
                name: "WaterLights");
        }
    }
}
