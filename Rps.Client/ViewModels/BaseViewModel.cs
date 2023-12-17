using Rps.BL;
using Rps.BL.Contracts;
using Rps.Client.Extra;
using Rps.DAL;
using Rps.Domain;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Rps.Client.ViewModels
{
    public abstract class BaseViewModel : IDataErrorInfo, INotifyPropertyChanged, ICommand
    {
        #region ICommand
        protected IUnitOfWork _unitOfWork;

        public BaseViewModel()
        {
            //AppSetting = _unitOfWork.SettingRepo.Get(1);
        }

        public BaseViewModel(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            AppSetting = _unitOfWork.SettingRepo.Get(1);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        #endregion ICommand

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

        #region IDataErrorInfo

        public abstract string this[string columnName] { get; }

        public string Error
        {
            get
            {
                string foutmeldingen = "";

                foreach (var item in this.GetType().GetProperties()) //reflection
                {
                    string fout = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(fout))
                    {
                        foutmeldingen += fout + Environment.NewLine;
                    }
                }
                return foutmeldingen;
            }
        }

        #endregion IDataErrorInfo

        #region helpmethodes

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);
        }

        #endregion helpmethodes

        public event EventHandler<MvvmMessageBoxEventArgs> MessageBoxRequest;
        protected void MessageBox_Show(Action<MessageBoxResult> resultAction, string messageBoxText, string caption = "", MessageBoxButton button = MessageBoxButton.OK, MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None)
        {
            if (this.MessageBoxRequest != null)
            {
                this.MessageBoxRequest(this, new MvvmMessageBoxEventArgs(resultAction, messageBoxText, caption, button, icon, defaultResult, options));
            }
        }

        private Setting _appsetting;
        public Setting AppSetting
        {
            get { return _appsetting; }
            set { _appsetting = value; NotifyPropertyChanged(); }
        }
    }
}
