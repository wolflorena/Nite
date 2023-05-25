using Nite.API.Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

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

        public ICollection<SeasonDTO> TVShowSeasons { get; set; } = new List<SeasonDTO>();


        public int DaysUntilNewSeason
        {
            get
            {
                if (DateTime.TryParse(NewSeason, out DateTime newSeasonDate))
                {
                    TimeSpan timeUntilNewSeason = newSeasonDate.Date - DateTime.Today;
                    return timeUntilNewSeason.Days;
                }

                return -1; 
            }
        }
    }
}

