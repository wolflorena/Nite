using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Repository.Entities
{
    public class Watch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        public int UserId { get; set; }

        [ForeignKey("TVShowId")]
        public TVShow? TVShow { get; set; }
        public int TVShowId { get; set; }

        [ForeignKey("SeasonId")]
        public Season? Season { get; set; }
        public int SeasonId { get; set; }

        [ForeignKey("EpisodeId")]
        public Episode? Episode { get; set; }
        public int EpisodeId { get; set; }
    }
}
