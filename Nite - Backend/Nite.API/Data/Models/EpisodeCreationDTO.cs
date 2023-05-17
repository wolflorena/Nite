
using Nite.API.Repository.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class EpisodeCreationDTO
    {
        [Required]
        public int TVShowId { get; set; }

        [Required]
        public int SeasonId { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}