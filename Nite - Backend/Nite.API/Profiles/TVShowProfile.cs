using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Profiles
{
    public class TVShowProfile : Profile
    {
        public TVShowProfile()
        {
            CreateMap<TVShow, TVShowDTO>();
            CreateMap<TVShowCreationDTO, TVShow>();
            CreateMap<TVShow, TVShowUpdateDTO>();
            CreateMap<TVShowUpdateDTO, TVShow>();
        }
    }
}
