using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_identity_details")]
    public class IdentityDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ClientDetailsId { get; set; }
        public ClientDetailsModel ClientDetails { get; set; }
        public string IdentificationType { get; set; }
        public string CountryOfIssure { get; set; }
        public string IdentificationNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}