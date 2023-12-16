using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedRobotClass_RemovedTotalScorePropertyFromPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "NameRobot",
                table: "RpsMatchesPlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RoundsPlayed",
                table: "RpsMatchesPlayed",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameRobot",
                table: "RpsMatchesPlayed");

            migrationBuilder.DropColumn(
                name: "RoundsPlayed",
                table: "RpsMatchesPlayed");

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "Players",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
