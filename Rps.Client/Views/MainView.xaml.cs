using Rps.Client.Extra;
using Rps.Client.ViewModels;
using System.Windows;
using System.Windows.Controls;
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
        void MyView_MessageBoxRequest(object sender, MvvmMessageBoxEventArgs e)
        {
            e.Show();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tabItem = ((sender as TabControl).SelectedItem as TabItem).Name as string;
            switch (tabItem)
            {
                case "tabMainMenu":
                    ContentWindow.Content = new MainMenuWindow();
                    var viewModelMainView = new MainMenuViewModel();
                    ContentWindow.DataContext = viewModelMainView;
                    break;

                default:
                    return;
            }
        }
    }
}
