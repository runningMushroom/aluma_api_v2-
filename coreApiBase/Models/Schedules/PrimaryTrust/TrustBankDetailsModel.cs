using alumaApi.Models.Schedules.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryTrust
{
    [Table("primary_schedule_trust_bank_details")]
    public class TrustBankDetailsModel : BaseBankDetailsModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryTrustModel Schedule { get; set; }
    }
}