using Rps.Client.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Rps.Client.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            ContentWindow.Content = new MainMenuWindow();
            var viewModelMainView = new MainMenuViewModel();
            ContentWindow.DataContext = viewModelMainView;

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
