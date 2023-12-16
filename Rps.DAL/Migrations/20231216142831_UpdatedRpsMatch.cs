using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedRpsMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RpsMatchesPlayed_Robots_RobotId",
                table: "RpsMatchesPlayed");

            migrationBuilder.DropColumn(
                name: "NameRobot",
                table: "RpsMatchesPlayed");

            migrationBuilder.RenameColumn(
                name: "RobotId",
                table: "RpsMatchesPlayed",
                newName: "RobotInMatchId");

            migrationBuilder.RenameIndex(
                name: "IX_RpsMatchesPlayed_RobotId",
                table: "RpsMatchesPlayed",
                newName: "IX_RpsMatchesPlayed_RobotInMatchId");

            migrationBuilder.RenameColumn(
                name: "PlayerName",
                table: "Robots",
                newName: "RobotName");

            migrationBuilder.AddForeignKey(
                name: "FK_RpsMatchesPlayed_Robots_RobotInMatchId",
                table: "RpsMatchesPlayed",
                column: "RobotInMatchId",
                principalTable: "Robots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RpsMatchesPlayed_Robots_RobotInMatchId",
                table: "RpsMatchesPlayed");

            migrationBuilder.RenameColumn(
                name: "RobotInMatchId",
                table: "RpsMatchesPlayed",
                newName: "RobotId");

            migrationBuilder.RenameIndex(
                name: "IX_RpsMatchesPlayed_RobotInMatchId",
                table: "RpsMatchesPlayed",
                newName: "IX_RpsMatchesPlayed_RobotId");

            migrationBuilder.RenameColumn(
                name: "RobotName",
                table: "Robots",
                newName: "PlayerName");

            migrationBuilder.AddColumn<string>(
                name: "NameRobot",
                table: "RpsMatchesPlayed",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_RpsMatchesPlayed_Robots_RobotId",
                table: "RpsMatchesPlayed",
                column: "RobotId",
                principalTable: "Robots",
                principalColumn: "Id");
        }
    }
}
