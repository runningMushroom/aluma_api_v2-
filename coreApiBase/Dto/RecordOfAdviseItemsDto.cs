using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class RecordOfAdviseItemsDto
    {
        public Guid RecordOfAdviseId { get; set; }
        public string ProductName { get; set; }
        public double RecommendedLumpSum { get; set; }
        public double AcceptedLumpSum { get; set; }
        public double RecommendedRecurringPremium { get; set; }
        public double AcceptedRecurringPremium { get; set; }
        public string DeveationReason { get; set; }
    }
}