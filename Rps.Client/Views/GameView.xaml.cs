using System.Windows.Controls;

namespace Rps.Client.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public GameView()
        {
            InitializeComponent();
            //show module that asks for name OR use more user controles within this one
            //one for the name
            //one for the option
            //s and the result screen
            ContentWindow.Content = new PlayerNameInputView(this);
        }
        public void GoToTEST()
        {
            ContentWindow.Content = new PlayingFieldView();
        }
    }
}
