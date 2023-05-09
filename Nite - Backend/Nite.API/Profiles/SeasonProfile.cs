using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Profiles
{
    public class SeasonProfile : Profile
    {
        public SeasonProfile()
        {
            CreateMap<Season, SeasonDTO>();
            CreateMap<SeasonCreationDTO, Season>();
            CreateMap<Season, SeasonUpdateDTO>();
            CreateMap<SeasonUpdateDTO, Season>();
        }
    }
}