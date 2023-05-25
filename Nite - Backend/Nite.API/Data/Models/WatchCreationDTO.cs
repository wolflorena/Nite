using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class WatchCreationDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TVShowId { get; set; }
        [Required]
        public int SeasonId { get; set; }
        [Required]
        public int EpisodeId { get; set; }
    }
}
