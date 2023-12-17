namespace Rps.Domain
{
    public class HighScore
    {
        public string CompetitorName { get; set; } = string.Empty;
        public int GamesWon { get; set; } = 0;
        public int Winrate { get; set; } = 0;

    }
}
