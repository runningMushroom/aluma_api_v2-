using AutoMapper;
using Entities.Dto;
using alumaApi.Dto;
using alumaApi.Models;

namespace alumaApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Users
            CreateMap<RegistrationDto, UserModel>()
                .ReverseMap();
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
        }
    }
}