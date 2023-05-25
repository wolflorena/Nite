using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Profiles
{
    public class FavoritesProfile : Profile
    {
        public FavoritesProfile()
        {
            CreateMap<Favorites, FavoritesDTO>();
            CreateMap<FavoritesCreationDTO, Favorites>();
        }
    }
}
