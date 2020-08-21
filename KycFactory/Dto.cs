﻿using System;
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
}