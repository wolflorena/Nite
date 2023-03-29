using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class TVShowUpdateDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string? Audience { get; set; }
        [Required]
        public int Seasons { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public string? Status { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
