using System.ComponentModel.DataAnnotations;

namespace MyFirstBackend.Models.DataModels
{
    public enum Role
    {
        User,
        Administrator
    }
    public class User : BaseEntity
    {
        

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public Role Role { get; set; } = Role.User;

    }

    
}
