using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.Shared
{
    public class BaseBankDetailsModel : BaseModel
    {
        public string AccountHolder { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string BranchNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
    }
}