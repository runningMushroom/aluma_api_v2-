using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryIndividual
{
    public class IdentityDetailsDto
    {
        public Guid ClientDetailsId { get; set; }
        public string IdentificationType { get; set; }
        public string CountryOfIssure { get; set; }
        public string IdentificationNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}