using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Enum;

namespace alumaApi.Models
{
    public class OtpModel
    {
        public Guid Id { get; set; }
        public string ClientEmail { get; set; }
        public OtpTypesEnum OtpType { get; set; }
        public string Otp { get; set; }
    }
}