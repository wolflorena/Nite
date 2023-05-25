using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class AddCreationDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TVShowId { get; set; }
    }
}
