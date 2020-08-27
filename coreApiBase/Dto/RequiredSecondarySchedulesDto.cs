using alumaApi.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class RequiredSecondarySchedulesDto
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
        public ScheduleTypesEnum ScheduleType { get; set; }
        public ICollection<RequiredSecondarySchedulesContactsDto> Contacts { get; set; }
    }
}