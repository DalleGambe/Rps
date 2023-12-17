using System.ComponentModel.DataAnnotations;

namespace Rps.Contracts.Enumerations
{
    public enum WeaponOption
    {
        [Display(Name = "None")]
        None,
        [Display(Name = "Pistol")]
        Pistol,
        [Display(Name = "Scissors")]
        Scissors,
        [Display(Name = "Rock")]
        Rock,
        [Display(Name = "Paper")]
        Paper,
    }
}
