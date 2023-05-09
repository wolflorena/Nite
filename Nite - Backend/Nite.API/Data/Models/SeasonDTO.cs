using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class SeasonDTO
    {
        public int Id { get; set; }
        public int TVShowId { get; set; }
        public string? Name { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int DurationEpisode { get; set; }
    }
}
