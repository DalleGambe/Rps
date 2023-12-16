using System.ComponentModel.DataAnnotations;

namespace Rps.Domain
{
    public class RpsMatch : BasicEntity
    {
        [Required]
        public int ScorePlayer { get; set; } = 0;
        [Required]
        public int ScoreRobot { get; set; } = 0;
        [Required]
        public int RoundsPlayed { get; set; } = 0;
        public DateTime DatePlayed { get; set; } = DateTime.Now;
        public Player? PlayerInMatch { get; set; }
        public Robot? RobotInMatch { get; set; }
    }
}
