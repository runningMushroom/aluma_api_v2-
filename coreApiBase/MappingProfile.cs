using AutoMapper;
using alumaApi.Dto;
using alumaApi.Models;
using alumaApi.Enum;
using System.Linq;

namespace alumaApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Applications
            CreateMap<ApplicationStepModel, ApplicationStepsDto>()
                .ForMember(d => d.StepType, opt => opt.ConvertUsing(new ApplStepTypeEnumToString()))
                .ReverseMap();

            CreateMap<ApplicationsModel, ApplicationDto>()
                .ForMember(
                    dest => dest.Steps,
                    opt => opt.MapFrom(src => src.Steps))
                .ReverseMap();

            // Users
            CreateMap<RegistrationDto, UserModel>()
                .ReverseMap();

            CreateMap<UserModel, UserModelDto>()
                .ReverseMap();
        }
    }

    public class ApplStepTypeEnumToString : IValueConverter<ApplicationStepTypesEnum, string>
    {
        public string Convert(ApplicationStepTypesEnum sourceMember, ResolutionContext context) =>
            sourceMember.ToString();
    }
}