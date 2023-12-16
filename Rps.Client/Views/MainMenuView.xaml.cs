using Rps.Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Rps.Client.Views
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : UserControl
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }
        //Starts the game

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new GameView();
            var viewModelGameView = new GameViewModel();
            DataContext = viewModelGameView;
        }
        //Shows the player the option menu
        private void OptionButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new OptionView();
            var viewModelOptionView = new OptionViewModel();
            DataContext = viewModelOptionView;
        }
        //Shows the player the highscore screen
        private void HighScoreButton_Click(object sender, RoutedEventArgs e)
        {
            Content = new HighscoreView();
            var viewModelHighscoreView = new HighscoreViewModel();
            DataContext = viewModelHighscoreView;
        }
        //Shuts down the application
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
