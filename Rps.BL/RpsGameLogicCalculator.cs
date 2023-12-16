using Rps.BL.Contracts;
using Rps.Contracts.Enumerations;

namespace Rps.BL
{
    public class RpsGameLogicCalculator : IRpsGameLogicCalculator
    {
        Random random = new Random();

        public MatchOutcome DidPlayerWin(WeaponOption playerWeaponChoice, WeaponOption robotWeaponChoice)
        {
            switch (playerWeaponChoice.GetPropertyDisplayName().ToLower() + robotWeaponChoice.GetPropertyDisplayName().ToLower())
            {
                //If Player and Ai have the same weapon return a tie (pistol not present since ai can't get it)
                case "scissorsscissors":
                case "rockrock":
                case "paperpaper":
                    return MatchOutcome.Tie;
                //If player has any weapon that matches one of these outputs they win
                case "scissorspaper":
                case "paperrock":
                case "rockscissors":
                case "pistolscissors":
                case "pistolrock":
                case "pistolpaper":
                    return MatchOutcome.Win;
                //If it's not a tie and the player does not win, Ai wins
                default:
                    return MatchOutcome.Lose;
            }
        }

        public bool DoesPistolAppearThisRound()
        {
            //Pistol has 10% chance to make an appearance
            return random.Next(1, 10) == 10;
        }

        public WeaponOption GetRobotWeaponPick()
        {
            WeaponOption weaponChosenByRobot = WeaponOption.Pistol;
            Array values = Enum.GetValues(typeof(WeaponOption));
            while (weaponChosenByRobot == WeaponOption.Pistol)
            {
                weaponChosenByRobot = (WeaponOption)values.GetValue(random.Next(values.Length));
            }
            return weaponChosenByRobot;
        }
    }
}
