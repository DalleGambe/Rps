using System.ComponentModel.DataAnnotations;

namespace Rps.Domain
{
    public class Setting : BasicEntity
    {
        [Required]
        public int MasterVolume { get; set; } = 60;
    }
}
