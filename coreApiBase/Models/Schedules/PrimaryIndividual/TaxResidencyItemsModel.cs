using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_tax_residency_items")]
    public class TaxResidencyItemsModel
    {
        public Guid Id { get; set; }
        public Guid TasResidencyId { get; set; }
        public TaxResidencyModel TaxResidency { get; set; }
        public string Country { get; set; }
        public string TinNumber { get; set; }
        public string TinUnavailableReason { get; set; }
    }
}