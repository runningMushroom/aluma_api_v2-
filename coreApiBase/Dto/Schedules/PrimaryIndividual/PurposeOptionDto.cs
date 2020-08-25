using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryIndividual
{
    public class PurposeOptionDto
    {
        public Guid PurposeAndFundingId { get; set; }
        public string InvestingIn { get; set; }
        public string Objective { get; set; }
        public string TimeFrame { get; set; }
        public string Activity { get; set; }
    }
}