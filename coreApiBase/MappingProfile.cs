using AutoMapper;
using alumaApi.Dto;
using alumaApi.Models;
using alumaApi.Enum;
using System.Linq;
using alumaApi.Models.Schedules;
using alumaApi.Dto.Schedules;
using alumaApi.Models.Schedules.PrimaryIndividual;
using alumaApi.Dto.Schedules.PrimaryIndividual;

namespace alumaApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // AdvisorAdvise
            CreateMap<AdvisorAdvisedProductsModel, AdvisorAdvisedProductsDto>()
                .ReverseMap();

            // AdvisorAdvisedProducts
            CreateMap<AdvisorAdviseModel, AdvisorAdviseDto>()
                .ReverseMap();

            // ApplicationDcouments
            CreateMap<ApplicationDocumentsModel, ApplicationDocumentsDto>()
                .ForMember(d => d.DocuemtnData, opt => opt.ConvertUsing(new ByteToString()));

            CreateMap<ApplicationDocumentsDto, ApplicationDocumentsModel>()
                .ForMember(d => d.DocuemtnData, opt => opt.ConvertUsing(new StringToByte()));

            // ApplicationSteps
            CreateMap<ApplicationStepModel, ApplicationStepsDto>()
                .ForMember(d => d.StepType, opt => opt.ConvertUsing(new ApplStepTypeEnumToString()))
                .ReverseMap();

            // Bank Details
            CreateMap<BankVerificationsModel, BankVerificationsDto>()
                .ReverseMap();

            // Applications
            CreateMap<ApplicationsModel, ApplicationDto>()
                .ForMember(
                    dest => dest.Steps,
                    opt => opt.MapFrom(src => src.Steps))
                .ReverseMap();

            // Users Regsitration
            CreateMap<RegistrationDto, UserModel>()
                .ReverseMap();

            // Users
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            // Schedules
            // Schedule Primary Individual
            CreateMap<PrimaryIndividualModel, PrimaryIndividualDto>()
                .ReverseMap();

            CreateMap<ClientDetailsModel, ClientDetailsDto>()
                .ReverseMap();

            CreateMap<ContactDetailsModel, ContactDetailsDto>()
                .ReverseMap();

            CreateMap<IdentityDetailsModel, IdentityDetailsDto>()
                .ReverseMap();

            CreateMap<PurposeAndFundingModel, PurposeAndFundingDto>()
                .ReverseMap();

            CreateMap<PurposeOptionModel, PurposeOptionDto>()
                .ReverseMap();

            CreateMap<TaxResidencyModel, TaxResidencyDto>()
                .ReverseMap();

            CreateMap<TaxResidencyItemsModel, TaxResidencyItemsDto>()
                .ReverseMap();
        }
    }

    public class ApplStepTypeEnumToString : IValueConverter<ApplicationStepTypesEnum, string>
    {
        public string Convert(ApplicationStepTypesEnum sourceMember, ResolutionContext context) =>
            sourceMember.ToString();
    }

    public class StringToByte : IValueConverter<string, byte[]>
    {
        public byte[] Convert(string sourceMember, ResolutionContext context) =>
            System.Convert.FromBase64String(sourceMember);
    }

    public class ByteToString : IValueConverter<byte[], string>
    {
        public string Convert(byte[] sourceMember, ResolutionContext context) =>
            System.Convert.ToBase64String(sourceMember);
    }
}