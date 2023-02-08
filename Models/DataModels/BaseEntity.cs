using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

    }
}
