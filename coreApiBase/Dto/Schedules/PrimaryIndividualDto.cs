using alumaApi.Dto.Schedules.PrimaryIndividual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules
{
    public class PrimaryIndividualDto
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public ClientDetailsDto ClientDetails { get; set; }
        public ContactDetailsDto ContactDetails { get; set; }
        public PurposeAndFundingDto PurposeAndFunding { get; set; }
        public TaxResidencyDto TaxResidency { get; set; }
    }
}