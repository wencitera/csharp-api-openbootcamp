using System.ComponentModel.DataAnnotations;

namespace MyFirstBackend.Models.DataModels
{
    public enum Level { 
    Basic,
    Medium,
    Advanced,
    Expert
    }
    public class Course : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(180)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public Level Level { get; set; } = Level.Basic;

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

        //public int ChapterId { get; set; }
        //public virtual Chapter Chapter { get; set; } = new Chapter();
        
    }
}
