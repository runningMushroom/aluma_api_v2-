using alumaApi.Dto.Schedules.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryTrust
{
    public class TrustBankDetailsDto : BaseBankDetailsDto
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
    }
}