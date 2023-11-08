using System;
using System.Windows;

namespace Rps.Client.ViewModels
{
    public class MainMenuViewModel : BaseViewModel, IDisposable
    {
        public override string this[string columnName]
        {
            get { return ""; }
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void Dispose()
        {
            ////Remove unitofwork if no longer needed
            //throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "Shutdown": Shutdown(); break;
            }
        }
        //Shuts down the current application
        private void Shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}
