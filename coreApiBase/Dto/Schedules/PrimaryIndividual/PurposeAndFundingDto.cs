using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryIndividual
{
    public class PurposeAndFundingDto
    {
        public ICollection<PurposeOptionDto> PurposeOptions { get; set; }
        public string NumberOfDeposits { get; set; }
        public string NumberOfWithdrrawals { get; set; }
        public string DepositsValue { get; set; }
        public string WithdrawalsValue { get; set; }
        public string SourceOfFunds { get; set; }
        public string SourceOfWealth { get; set; }
    }
}