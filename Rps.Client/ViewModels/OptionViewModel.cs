using Rps.BL.Contracts;
using Rps.Domain;
using System;
using System.Linq;

namespace Rps.Client.ViewModels
{
    public class OptionViewModel : BaseViewModel
    {
        public OptionViewModel(IUnitOfWork unitOfWork) : base(unitOfWork) {
            MasterVolume = _unitOfWork.SettingRepo.GetAll().FirstOrDefault();
        }
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
                case "SaveSettings": SaveSettings(); break;
            }
        }

        //ContentWindow for the MainView from The Game
        private Setting _masterVolume;

        public Setting MasterVolume
        {
            get => _masterVolume;
            set
            {
                if (_masterVolume != value)
                {
                    _masterVolume = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void SaveSettings()
        {
            _unitOfWork.SettingRepo.Change(MasterVolume);
            _unitOfWork.Save();
        }
    }
}
