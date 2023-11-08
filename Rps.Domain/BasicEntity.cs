using System.ComponentModel.DataAnnotations;

namespace Rps.Domain
{
    public class BasicEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
