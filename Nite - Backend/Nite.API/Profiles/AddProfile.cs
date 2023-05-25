using AutoMapper;
using Nite.API.Data.Models;
using Nite.API.Repository.Entities;

namespace Nite.API.Profiles
{
    public class AddProfile : Profile
    {
        public AddProfile()
        {
            CreateMap<Add, AddDTO>();
            CreateMap<AddCreationDTO, Add>();
        }
    }
}
