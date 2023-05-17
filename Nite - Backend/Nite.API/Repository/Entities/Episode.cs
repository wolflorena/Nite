
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Repository.Entities
{
    public class Episode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TVShowId")]
        public TVShow? TVShow { get; set; }
        public int TVShowId { get; set; }

        [ForeignKey("SeasonId")]
        public Season? Season { get; set; }
        public int SeasonId { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}