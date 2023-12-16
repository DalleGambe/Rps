using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rps.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingRobotsToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] robotNames = {
                "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Henry", "Ivy", "Jack", "Bryan", "Wolf", "Rock", "Stone", "Artsie",
                "BeeBoop", "ZigZag", "RoboNinja", "TickTock", "CircuitMan", "ByteSize", "TechTornado", "Sparky", "Gizmo", "MegaByte",
                "Xander", "Quark", "Nova", "Electra", "Titan", "Zephyr", "Nyx", "Orbit", "Cosmo", "Bob", "Blaze"
              };
            foreach (string robotName in robotNames)
            {
                migrationBuilder.InsertData(
                table: "Robots",
                columns: new[] { "RobotName", "GamesWon", "GamesPlayed", "LastUpdated" },
                values: new object[] { robotName, 0, 0, DateTime.Now });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
