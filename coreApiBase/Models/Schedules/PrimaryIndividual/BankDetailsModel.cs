using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_bank_details")]
    public class BankDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryIndividualModel Schedule { get; set; }
        public string AccountHolder { get; set; }
        public string Bank { get; set; }
        public string Branc { get; set; }
        public string BrancNumber { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
    }
}