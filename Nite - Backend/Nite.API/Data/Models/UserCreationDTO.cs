using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class UserCreationDTO
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Gender { get; set; }
        public string? Birthdate { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
