using System.Windows.Controls;

namespace Rps.Client.Views
{
    /// <summary>
    /// Interaction logic for PlayerNameInputView.xaml
    /// </summary>
    public partial class PlayerNameInputView : UserControl
    {
        GameView gameView;

        public PlayerNameInputView(GameView view)
        {
            InitializeComponent();
            gameView = view;
        }

        private void btnPickPlayerName_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gameView.GoToTEST();
        }
    }
}
