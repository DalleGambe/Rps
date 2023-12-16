using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSetting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MasterVolume = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerName = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    GamesWon = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalScore = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RpsMatchesPlayed",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerInMatchId = table.Column<int>(type: "INTEGER", nullable: true),
                    ScorePlayer = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreRobot = table.Column<int>(type: "INTEGER", nullable: false),
                    DatePlayed = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RpsMatchesPlayed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RpsMatchesPlayed_Players_PlayerInMatchId",
                        column: x => x.PlayerInMatchId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RpsMatchesPlayed_PlayerInMatchId",
                table: "RpsMatchesPlayed",
                column: "PlayerInMatchId");
            migrationBuilder.InsertData(
                table: "AppSetting",
                columns: new[] { "MasterVolume", "LastUpdated" },
                values: new object[] { 60, DateTime.Now });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting");

            migrationBuilder.DropTable(
                name: "RpsMatchesPlayed");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
