using Rps.BL;
using Rps.BL.Contracts;
using Rps.Client.Extra;
using Rps.Client.Views;
using Rps.Contracts.Enumerations;
using Rps.DAL;
using Rps.Domain;
using System;
using System.Linq;
using System.Windows;

namespace Rps.Client.ViewModels
{
    //What this needs:
    //Write it to the database
    //Update the score after a second game
    //TODO Add a feature where at launch all of the players in the database get removed if their isn't any rpsmatch record with their ID.
    //TODO add contentwindow to playingfield OR turn gameview into the playing field AND add conditional rendering to the stat labels
    //Contentwindow will be added to playingfield instead! Reason? Game act like the "mainhub" it allows players to choose what mode to pick player vs ai or player vs player (if it would be added in the future) -> better for extension z
    public class GameViewModel : MainViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public override string this[string columnName]
        {
            get { return ""; }
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public GameViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeObjects();
            CurrentContentGameView = new PlayerNameInputView();
        }

        Random random = new Random();

        private void InitializeObjects()
        {
            //Check if player with name exists if it does return their values instead otherwise create a new player in the database
            Player = new Player();
            IsPistolNotShown = _rpsGameLogicCalculator.DoesPistolNotAppearThisRound();
            RpsMatch = new RpsMatch();
            //Normally I would get the length OR write a seperate repo to get a random robot. Since I'm running low on time, this is hard coded and will be changed in the future after the deadline.
            RobotChosen = _unitOfWork.RobotRepo.Get(random.Next(1, 37));
            RpsMatch.RobotInMatch = RobotChosen;
        }

        //ContentWindow for the MainView from The Game
        private object _currentContentGameView;

        public object CurrentContentGameView
        {
            get => _currentContentGameView;
            set
            {
                if (_currentContentGameView != value)
                {
                    _currentContentGameView = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //Content for the PlayingFieldView
        private object _currentContentPlayingField;

        public object CurrentContentPlayingField
        {
            get => _currentContentPlayingField;
            set
            {
                if (_currentContentPlayingField != value)
                {
                    _currentContentPlayingField = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public override void Execute(object parameter)
        {
            //Check if parameter is contained in a displayname of the enum weaponchoice
            foreach (WeaponOption weapon in Enum.GetValues(typeof(WeaponOption)))
            {
                //If it is apply the value to WeaponChosen
                if (weapon.GetPropertyDisplayName() == parameter.ToString())
                {
                    WeaponChosenByPlayer = weapon;
                    break;
                }
            }
            switch (parameter)
            {
                case "PlayGame": GoToPlayingField(); break;
                case "Scissors":
                case "Rock":
                case "Paper":
                case "Pistol":
                    ShowResult(); break;
            }
        }

        private void GoToPlayingField()
        {
            if (Player.PlayerName.Length > 0)
            {
                CurrentContentGameView = new PlayingFieldView();
                CurrentContentPlayingField = new ChooseWeaponView();
            }
            else
            {
                MvvmMessageBoxEventArgs nameTooShortModule = new MvvmMessageBoxEventArgs(
          (result) =>
          {
              //:Empty since nothing needs to happen
          },
          "Uh oh! It looks like your name is too short! Make sure that it is atleast one character long to continue!", //Content
          "Name too short", //Header
          MessageBoxButton.OK,
          MessageBoxImage.Warning
        );
                nameTooShortModule.Show();
            }
        }
        public event EventHandler<MvvmMessageBoxEventArgs> MessageBoxRequest;
        protected void MessageBox_Show(Action<MessageBoxResult> resultAction, string messageBoxText, string caption = "", MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None)
        {
            if (this.MessageBoxRequest != null)
            {
                this.MessageBoxRequest(this, new MvvmMessageBoxEventArgs(resultAction, messageBoxText, caption, button, icon, defaultResult, options));
            }
        }
        private void ShowResult()
        {
            WeaponOption weaponChosenByRobot = _rpsGameLogicCalculator.GetRobotWeaponPick();
            MatchOutcome roundOutcome = _rpsGameLogicCalculator.DidPlayerWin(WeaponChosenByPlayer, weaponChosenByRobot);
            string roundOutcomeMessage = string.Empty;
            if (roundOutcome == MatchOutcome.Win)
            {
                //Increase score of the Player
                RpsMatch.ScorePlayer++;
                //Set victory message
                roundOutcomeMessage = $"Naturally, {Player.PlayerName} is victorious!";
                //Notify that the property score for the player has changed
                NotifyPropertyChanged(nameof(PlayerStat));
            }
            else if (roundOutcome == MatchOutcome.Loss)
            {
                //Increase score of the Robot
                RpsMatch.ScoreRobot++;
                //Notify that the property score for the robot has changed
                NotifyPropertyChanged(nameof(RobotStat));
                //Set loss message
                roundOutcomeMessage = $"Despite all odds, {RobotChosen.RobotName} is the winner!";
            }
            else
            {
                //Set tie message
                roundOutcomeMessage = $"Unfortunately, despite the efforts of both parties the battle ends with a tie!";
            }
            //Increase Roundcount
            RpsMatch.RoundsPlayed++;
            RpsMatch.LastUpdated = DateTime.Now;
            NotifyPropertyChanged(nameof(CurrentRound));

            //Add Player to the match and database if it hasn't been done yet
            AddPlayerToMatchAndDb();

            //Create or Update RpsMatch based on it's id
            _unitOfWork.RpsMatchRepo.AddToDbOrChange(RpsMatch);

            //Save changes
            _unitOfWork.Save();

            //Use custom messagebox to display the results
            MvvmMessageBoxEventArgs messageBoxArgs = new MvvmMessageBoxEventArgs(
           (result) =>
           {
               //Case YES
               if (result == MessageBoxResult.Yes)
               {
                   //Reset Everything (Choice Player, Does Gun Appear or not
                   ResetCurrentMatchOptions();
               }
               //Case NO
               else if (result == MessageBoxResult.No)
               {
                   UpdateGamesPlayedAndWon();

                   //Dispose of Unit Of Work
                   //_unitOfWork.Dispose();
                   //Go back to MainMenu
                   CurrentMainWindowContent = new MainMenuWindow();
               }
           },
           $"You ({Player.PlayerName}) chose the following weapon: {WeaponChosenByPlayer}\n{RobotChosen.RobotName} chose the following weapon: {weaponChosenByRobot}\nNot long after, both of you start exchanging hits! {roundOutcomeMessage} Continue?",
           "Result of combat!",
           MessageBoxButton.YesNo, //Buttons in the module
           MessageBoxImage.Information //Type of image in the module
       );

            // Show the MessageBox (with or without an owner window)
            messageBoxArgs.Show();
        }

        private void UpdateGamesPlayedAndWon()
        {
            //Update GamesPlayed for Robot and Player
            Player.GamesPlayed++;
            RobotChosen.GamesPlayed++;

            //Update GamesWon for Robot or Player based on who won
            UpdateGamesPlayedOfWhoWon();

            //Update Player
            _unitOfWork.PlayerRepo.Change(Player);

            //Update Robot
            _unitOfWork.RobotRepo.Change(RobotChosen);

            //Save changes
            _unitOfWork.Save();
        }

        private void UpdateGamesPlayedOfWhoWon()
        {
            if (RpsMatch.ScorePlayer != RpsMatch.ScoreRobot)
            {
                if (RpsMatch.ScorePlayer > RpsMatch.ScoreRobot)
                {
                    Player.GamesWon++;
                }
                else
                {
                    RobotChosen.GamesWon++;
                }
            }
        }

        private void ResetCurrentMatchOptions()
        {
            WeaponChosenByPlayer = WeaponOption.None;
            IsPistolNotShown = _rpsGameLogicCalculator.DoesPistolNotAppearThisRound();
        }

        //Rps game calculator
        private IRpsGameLogicCalculator _rpsGameLogicCalculator = new RpsGameLogicCalculator();

        //Player
        private Player _player;
        public Player Player
        {
            get { return _player; }
            set { _player = value; NotifyPropertyChanged(); }
        }

        //Is Pistol shown during the round?
        private bool _isPistolNotShown;
        public bool IsPistolNotShown
        {
            get { return _isPistolNotShown; }
            set { _isPistolNotShown = value; NotifyPropertyChanged(); }
        }

        //Weapon Chosen By Player
        private WeaponOption _weaponChosen;
        public WeaponOption WeaponChosenByPlayer
        {
            get { return _weaponChosen; }
            set { _weaponChosen = value; NotifyPropertyChanged(); }
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
            set
            {
                _rpsMatch = value;
                NotifyPropertyChanged(nameof(RpsMatch));
            }
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
            get { return $"Round {RpsMatch.RoundsPlayed + 1}"; }
        }

        //Adds a player to the database and links it to the current match
        private void AddPlayerToMatchAndDb()
        {
            if (RpsMatch.PlayerInMatch == null)
            {
                int playerId;
                //Check if player with name exists in database
                Player existingPlayerData = _unitOfWork.PlayerRepo.GetAll(player => player.PlayerName == Player.PlayerName).FirstOrDefault();
                if (existingPlayerData == null)
                {
                    //Create Player in database and return it's id if it does not exist
                    playerId = _unitOfWork.PlayerRepo.AddToDbReturnId(Player);
                }
                else
                {
                    //Overwrite PlayerData
                    Player = existingPlayerData;
                }
                //Add the player to the rpsmatch object
                RpsMatch.PlayerInMatch = Player;
            }
        }
    }
}
