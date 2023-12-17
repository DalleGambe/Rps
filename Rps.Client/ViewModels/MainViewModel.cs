using System.Windows;

namespace Rps.Client.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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
                //taskbar
                case "Shutdown": Shutdown(); break;
                case "Minimize": Minimize(); break;
            }
        }
        public MainViewModel()
        {
            CurrentMainWindowContent = new MainMenuViewModel();
            //ActiveViewModel = new MainMenuViewModel();
        }

        #region ContentWindow
        //Content for the MainWindow
        private object _currentMainWindowContent;

        public object CurrentMainWindowContent
        {
            get => _currentMainWindowContent;
            set
            {
                _currentMainWindowContent = value;
                NotifyPropertyChanged(nameof(CurrentMainWindowContent));
            }
        }

        ////Active ViewModel
        //private BaseViewModel _activeViewModel;

        //public object ActiveViewModel
        //{
        //    get => _activeViewModel;
        //    set
        //    {
        //        _activeViewModel = value;
        //        NotifyPropertyChanged(nameof(ActiveViewModel));
        //    }
        //}
        #endregion

        #region Taskbar

        //Current window status
        private WindowState _curWindowState;

        public WindowState CurWindowState
        {
            get
            {
                return _curWindowState;
            }
            set
            {
                _curWindowState = value;
                NotifyPropertyChanged("CurWindowState");
            }
        }

        //Minimalises the application
        private void Minimize()
        {
            CurWindowState = WindowState.Minimized;
        }

        //Shuts down the current application
        private void Shutdown()
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
