using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Repository.Entities
{
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TVShowId")]
        public TVShow? TVShow { get; set; }
        public int TVShowId { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public int NumberOfEpisodes { get; set; }
        [Required]
        public int DurationEpisode { get; set; }
    }
}
