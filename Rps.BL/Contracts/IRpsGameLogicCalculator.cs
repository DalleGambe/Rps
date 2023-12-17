using Rps.Contracts.Enumerations;

namespace Rps.BL.Contracts
{
    public interface IRpsGameLogicCalculator
    {
        /// <summary>
        /// Calculates who wins the current round!
        /// </summary>
        /// <param name="playerWeaponChoice"></param>
        /// <returns></returns>
        MatchOutcome DidPlayerWin(WeaponOption playerWeaponChoice, WeaponOption robotWeaponChoice);

        /// <summary>
        /// Calculates if the pistol appears for the player in the current round.
        /// </summary>
        /// <returns></returns>
        bool DoesPistolNotAppearThisRound();

        /// <summary>
        /// Calculates what weapon the robot picks for the current round!
        /// </summary>
        /// <returns></returns>
        WeaponOption GetRobotWeaponPick();
    }
}
