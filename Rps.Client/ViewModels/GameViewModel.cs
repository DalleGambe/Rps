using System;

namespace Rps.Client.ViewModels
{
    //What this needs:
    //String to show for player name
    //Make a player object
    //Make a match object
    //Write it to the database
    //Calculate score based on time and points
    //Update the score after a second game
    //Get RPS FIGHT logic from here https://github.com/DalleGambe/Minigame_App/blob/master/src/services/rpsData.service.ts
    public class GameViewModel : BaseViewModel, IDisposable
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
        }
    }
}
