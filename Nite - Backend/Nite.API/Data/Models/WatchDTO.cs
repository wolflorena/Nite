using Nite.API.Repository.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Nite.API.Data.Models
{
    public class WatchDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TVShowId { get; set; }
        public int SeasonId { get; set; }
        public int EpisodeId { get; set; }
    }
}
