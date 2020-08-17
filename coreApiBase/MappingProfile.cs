using AutoMapper;
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

            CreateMap<UserModel, UserModelDto>()
                .ReverseMap();
        }
    }
}