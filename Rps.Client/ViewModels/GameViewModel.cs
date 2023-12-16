using Rps.Domain;
using System;

namespace Rps.Client.ViewModels
{
    //What this needs:
    //String to show for player name
    //Make a player object
    //Make a match object
    //Write it to the database
    //Update the score after a second game
    //Get RPS FIGHT logic from here https://github.com/DalleGambe/Minigame_App/blob/master/src/services/rpsData.service.ts
    //TODO Add a feature where at launch all of the players in the database get removed if their isn't any rpsmatch record with their ID.
    //TODO add contentwindow to playingfield OR turn gameview into the playing field AND add conditional rendering to the stat labels
    public class GameViewModel : BaseViewModel, IDisposable
    {
        public override string this[string columnName]
        {
            get { return ""; }
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public GameViewModel()
        {
            InitializeObjects();
        }

        private void InitializeObjects()
        {
            //Check if player with name exists if it does return their values instead otherwise create a new player in the database
            Player = new Player(); 
            RpsMatch = new RpsMatch();
            RobotChosen = UnitOfWork.RobotRepo.Get(3);
        }

        public void Dispose()
        {
            ////Remove unitofwork if no longer needed
            //throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "Shutdown": AddPlayerToRpsMatch(); break;
            }
        }

        //Player
        private Player _player;
        public Player Player
        {
            get { return _player; }
            set { _player = value; NotifyPropertyChanged(); }
        }

        //Robot
        private Robot _robotChosen;
        public Robot RobotChosen
        {
            get { return _robotChosen; }
            set { _robotChosen = value; NotifyPropertyChanged(); }
        }

        //RpsMatch
        private RpsMatch _rpsMatch;
        public RpsMatch RpsMatch
        {
            get { return _rpsMatch; }
            set { _rpsMatch = value; NotifyPropertyChanged(); }
        }
        //Player stat
        public string PlayerStat
        {
            get { return $"{Player.PlayerName} - {RpsMatch.ScorePlayer}"; }
        }
        //Robot stat
        public string RobotStat
        {
            get { return $"{RobotChosen.RobotName} (AI) - {RpsMatch.ScoreRobot}"; }
        }

        //Current Round
        public string CurrentRound
        {
            get { return $"Round {RpsMatch.RoundsPlayed+1}"; }
        }

        //Adds a player to the database and links it to the current match
        private void AddPlayerToRpsMatch()
        {
            //Check if player with name exists in database
            //code
            //If it does return it's id
            //code
            //Otherwise
            //Create Player in database and return it's id
            int PlayerId = UnitOfWork.PlayerRepo.AddToDbReturnId(Player);
            //Get the data of the newly created player and add it to the rpsmatch object
            RpsMatch.PlayerInMatch = UnitOfWork.PlayerRepo.Get(PlayerId); 
        }
    }
}
