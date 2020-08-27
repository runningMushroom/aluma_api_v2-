using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class RequiredSecondarySchedulesContactsDto
    {
        public Guid ApplicationId { get; set; }
        public Guid RequiredSecondarySchedulesId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobileNumber { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
    }
}