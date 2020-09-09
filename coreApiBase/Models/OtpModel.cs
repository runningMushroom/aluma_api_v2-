using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Enum;

namespace alumaApi.Models
{
    [Table("otp")]
    public class OtpModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ClientEmail { get; set; }
        public OtpTypesEnum OtpType { get; set; }
        public string Otp { get; set; }
        public Guid RelatedDataId { get; set; }
    }
}