using Rps.BL.Contracts;
using Rps.Client.Views;
using Rps.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Rps.Client.ViewModels
{
    public class HighscoreViewModel : MainViewModel
    {


        public HighscoreViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            HighScores = GetDisplayHighScores();
        }


        //HighScores to display
        private List<string> _highScores;
        public List<string> HighScores
        {
            get { return _highScores; }
            set
            {
                _highScores = value;
                NotifyPropertyChanged(nameof(HighScores));
            }
        }

        private List<string> GetDisplayHighScores()
        {
            int rank = 1;
            List<string> tmpList = new List<string>();
            foreach (var score in CalculateHighScores())
            {
                tmpList.Add($"{rank}. Name: {score.CompetitorName} - Games won: {score.GamesWon} - Winrate: {score.Winrate}%");
                rank++;
            }
            return tmpList;
        }

        private List<HighScore> CalculateHighScores()
        {
            List<HighScore> ScoreList = new List<HighScore>();
          //Get 10 Highest Scores (Players and Ai's with most games wona)
          var topPlayers = _unitOfWork.PlayerRepo.GetAll().OrderByDescending(player => player.GamesWon).Take(10).ToList();
            var topRobots = _unitOfWork.RobotRepo.GetAll().OrderByDescending(robot => robot.GamesWon).Take(10).ToList();

            foreach (var player in topPlayers)
            {
                HighScore highScore = new HighScore()
                {
                    CompetitorName = player.PlayerName,
                    GamesWon = player.GamesWon,
                    Winrate = player.GamesWon == 0 ? 0 : (player.GamesWon / player.GamesPlayed) * 100
                };
                ScoreList.Add(highScore);
            }
            foreach (var robot in topRobots)
            {
                HighScore highScore = new HighScore()
                {
                    CompetitorName = $"{robot.RobotName} (AI)",
                    GamesWon = robot.GamesWon,
                    Winrate = robot.GamesWon == 0 ? 0 : (robot.GamesWon / robot.GamesPlayed) * 100
                };
                ScoreList.Add(highScore);
            }
            return ScoreList.OrderByDescending(score => score.GamesWon).Take(10).ToList();
        }

        public override string this[string columnName]
        {
            get { return ""; }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "GoToMainMenu":
                    NavigateToMainMenu();
                    break;
            }
        }

        private void NavigateToMainMenu()
        {
            CurrentMainWindowContent = new MainMenuWindow();
        }
    }
}

