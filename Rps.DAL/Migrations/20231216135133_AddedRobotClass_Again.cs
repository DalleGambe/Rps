using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRobotClass_Again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSetting",
                table: "AppSetting");

            migrationBuilder.RenameTable(
                name: "AppSetting",
                newName: "AppSettings");

            migrationBuilder.AddColumn<int>(
                name: "RobotId",
                table: "RpsMatchesPlayed",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSettings",
                table: "AppSettings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Robots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerName = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    GamesWon = table.Column<int>(type: "INTEGER", nullable: false),
                    GamesPlayed = table.Column<int>(type: "INTEGER", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Robots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RpsMatchesPlayed_RobotId",
                table: "RpsMatchesPlayed",
                column: "RobotId");

            migrationBuilder.AddForeignKey(
                name: "FK_RpsMatchesPlayed_Robots_RobotId",
                table: "RpsMatchesPlayed",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RpsMatchesPlayed_Robots_RobotId",
                table: "RpsMatchesPlayed");

            migrationBuilder.DropTable(
                name: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_RpsMatchesPlayed_RobotId",
                table: "RpsMatchesPlayed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppSettings",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "RobotId",
                table: "RpsMatchesPlayed");

            migrationBuilder.RenameTable(
                name: "AppSettings",
                newName: "AppSetting");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppSetting",
                table: "AppSetting",
                column: "Id");
        }
    }
}
