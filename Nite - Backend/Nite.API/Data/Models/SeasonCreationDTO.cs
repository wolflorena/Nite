using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class SeasonCreationDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public int NumberOfEpisodes { get; set; }
        [Required]
        public int DurationEpisode { get; set; }
    }
}