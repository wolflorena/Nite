using Nite.API.Repository.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nite.API.Data.Models
{
    public class FavoritesDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TVShowId { get; set; }
    }
}
