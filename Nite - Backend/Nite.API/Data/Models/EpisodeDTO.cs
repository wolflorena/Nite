using Nite.API.Repository.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public int TVShowId { get; set; }
        public int SeasonId { get; set; }
        public string? Name { get; set; }
    }
}
