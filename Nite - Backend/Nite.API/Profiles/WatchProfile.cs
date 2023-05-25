using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Profiles
{
    public class WatchProfile : Profile
    {
        public WatchProfile()
        {
            CreateMap<Watch, WatchDTO>();
            CreateMap<WatchCreationDTO, Watch>();
        }
    }
}
