using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_purpose_and_funding_option")]
    public class PurposeOptionModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid PurposeAndFundingId { get; set; }
        public PurposeAndFundingModel PurposeAndFunding { get; set; }
        public string InvestingIn { get; set; }
        public string Objective { get; set; }
        public string TimeFrame { get; set; }
        public string Activity { get; set; }
    }
}