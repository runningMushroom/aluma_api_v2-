using AutoMapper;
using Entities.Dto;
using vueBuilderApi.Dto;
using vueBuilderApi.Models;

namespace vueBuilderApi
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