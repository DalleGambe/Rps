using Rps.Client.ViewModels;
using System.Windows;

namespace Rps.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 
    //TODO Add font so it can be used on the text 
    //TODO Add custom icon to the program
    //TODO Add music to the program
    //TODO Add images (rps options) to the program
    //TODO Add sound effects to the program
    //TODO Finish optionview
    //TODO Finish startview
    //TODO Finish highscoreview
    //TODO Implement sqllite using unit of work
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainViewModel viewmodel = new MainViewModel();
            Views.MainView view = new Views.MainView();
            view.DataContext = viewmodel;
            view.Show();
        }
    }
}
