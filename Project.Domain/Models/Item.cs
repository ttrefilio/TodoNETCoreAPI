using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Models
{
    public class Item
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
