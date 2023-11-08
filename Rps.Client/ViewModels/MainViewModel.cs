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
            //throw new System.NotImplementedException();
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
