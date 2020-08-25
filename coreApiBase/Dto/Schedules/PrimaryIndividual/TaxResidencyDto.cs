using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryIndividual
{
    public class TaxResidencyDto
    {
        public Guid ScheduleId { get; set; }
        public string TaxNumber { get; set; }
        public bool TaxObligations { get; set; }
        public ICollection<TaxResidencyItemsDto> TaxResidencyItems { get; set; }
        public bool UsCitizen { get; set; }
        public bool UsRelinquished { get; set; }
        public bool UsOther { get; set; }
    }
}