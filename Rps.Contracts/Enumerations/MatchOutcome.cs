using System.ComponentModel.DataAnnotations;

namespace Rps.Contracts.Enumerations
{
    public enum MatchOutcome
    {
        [Display(Name = "Win")]
        Win,
        [Display(Name = "Tie")]
        Tie,
        [Display(Name = "Loss")]
        Loss,
    }
}
