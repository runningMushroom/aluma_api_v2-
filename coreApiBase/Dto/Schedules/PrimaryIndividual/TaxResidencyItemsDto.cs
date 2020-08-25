using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryIndividual
{
    public class TaxResidencyItemsDto
    {
        public Guid TasResidencyId { get; set; }
        public string Country { get; set; }
        public string TinNumber { get; set; }
        public string TinUnavailableReason { get; set; }
    }
}