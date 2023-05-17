using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Profiles
{
    public class EpisodeProfile : Profile
    {
        public EpisodeProfile()
        {
            CreateMap<Episode, EpisodeDTO>();
            CreateMap<EpisodeCreationDTO, Episode>();
            CreateMap<Episode, EpisodeUpdateDTO>();
            CreateMap<EpisodeUpdateDTO, Episode>();
        }
    }
}
