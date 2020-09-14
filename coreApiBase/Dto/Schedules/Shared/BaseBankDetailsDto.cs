using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.Shared
{
    public class BaseBankDetailsDto
    {
        public string AccountHolder { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string BranchNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
    }
}