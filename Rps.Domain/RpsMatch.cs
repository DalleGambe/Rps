using System.ComponentModel.DataAnnotations;

namespace Rps.Domain
{
    public class RpsMatch : BasicEntity
    {
        public Player? PlayerInMatch { get; set; }
        [Required]
        public int ScorePlayer { get; set; } = 0;
        [Required]
        public int ScoreRobot { get; set; } = 0;
        public DateTime DatePlayed { get; set; } = DateTime.Now;
    }
}
