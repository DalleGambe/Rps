using System.ComponentModel.DataAnnotations;

namespace Rps.Domain
{
    public class Player : BasicEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(12)]
        public string PlayerName { get; set; } = string.Empty;
        [Required]
        public int GamesWon { get; set; } = 0;
        [Required]
        public int GamesPlayed { get; set; } = 0;
        public List<RpsMatch> RpsMatches { get; set; } = new List<RpsMatch>();
    }
}
