using System;
using System.Collections.Generic;

namespace KycFactory
{
    public class KycSettingsDto
    {
        public string BaseUrl { get; set; }
        public string Authorization { get; set; }
        public string businessId { get; set; }
    }

    public class KycInitiationDto
    {
        public string BusinessId { get; set; }
        public ICollection<ConsumerDto> Consumers { get; set; }
    }

    public class ConsumerDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public bool SendEmail { get; set; }
        public bool IsCurrent { get; set; }
    }

    public class KycInitiationResponseDto
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int FactoryId { get; set; }
        public int NextStep { get; set; }
    }

    public class KycEventDto
    {
        public string EventDate { get; set; }
        public int FactoryId { get; set; }
        public string Identity { get; set; }
        public string EventType { get; set; }
        public string IdentityType { get; set; }
        public string EventResult { get; set; }
        public string CurrentStep { get; set; }
        public string NextStep { get; set; }
    }

    public class FactoryDetailsDto
    {
        public int factoryId { get; set; }
        public string idNumber { get; set; }
    }

    public class MetaDataDto
    {
        public IdVerifyDto IdVerify { get; set; }
    }

    public class IdVerifyDto
    {
        public RealTimeResultsDto RealTimeResults { get; set; }
    }

    public class RealTimeResultsDto
    {
        public string IdNumber { get; set; }
        public string FirstNames { get; set; }
        public string SurName { get; set; }
        public string Dob { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
        public string DeceasedStatus { get; set; }
        public string CellNumber { get; set; }
        public string Email { get; set; }
    }
}