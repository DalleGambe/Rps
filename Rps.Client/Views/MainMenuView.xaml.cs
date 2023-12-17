using Rps.BL.Contracts;
using Rps.BL;
using Rps.Client.ViewModels;
using Rps.DAL;
using System.Windows;
using System.Windows.Controls;

namespace Rps.Client.Views
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : UserControl
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new RpsDataContext());

        public MainMenuWindow()
        {
            InitializeComponent();
        }
        //Starts the game

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new GameView();
            var viewModelGameView = new GameViewModel(_unitOfWork);
            DataContext = viewModelGameView;
        }
        //Shows the player the option menu
        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new OptionView();
            var viewModelOptionView = new OptionViewModel(_unitOfWork);
            DataContext = viewModelOptionView;
        }
        //Shows the player the highscore screen
        private void HighScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new HighscoreView();
            var viewModelHighscoreView = new HighscoreViewModel(_unitOfWork);
            DataContext = viewModelHighscoreView;
        }
        //Shuts down the application
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
