using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rps.Domain
{
    public class BasicEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
