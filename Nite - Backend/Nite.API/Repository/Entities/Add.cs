using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Repository.Entities
{
    public class Add
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
    }
}
