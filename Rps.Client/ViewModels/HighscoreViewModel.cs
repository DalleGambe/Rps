using System;

namespace Rps.Client.ViewModels
{
    public class HighscoreViewModel : BaseViewModel, IDisposable
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
            UnitOfWork.Dispose();
        }

        public override void Execute(object parameter)
        {
            switch (parameter)
            {
                case "Shutdown": Test(); break;
            }
        }

        //Shuts down the current application
        private void Test()
        {
            
        }
    }
}

