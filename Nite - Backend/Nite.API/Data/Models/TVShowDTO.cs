using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nite.API.Data.Models
{
    public class TVShowDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public string? Audience { get; set; }
        public int Seasons { get; set; }
        public string? Genre { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public string? Streaming { get; set; }
        public int Likes { get; set; }
        public string? NewSeason { get; set; }
        public string? Poster { get; set; }
        public IFormFile? PosterFile { get; set; }
        public string? Banner { get; set; }

        public IFormFile? BannerFile { get; set; }

        public string? Logo { get; set; }

        public IFormFile? LogoFile { get; set; }
    }
}

