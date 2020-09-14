using alumaApi.Dto.Schedules.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryTrust
{
    public class TrustTaxResidencyDto : BaseTaxResidencyDto
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public ICollection<TrustTaxResidencyItemDto> TaxResidencyItems { get; set; }
    }

    public class TrustTaxResidencyItemDto : BaseTaxResidencyItemDto
    {
        public Guid Id { get; set; }
        public Guid TrustTaxResidencyId { get; set; }
    }
}