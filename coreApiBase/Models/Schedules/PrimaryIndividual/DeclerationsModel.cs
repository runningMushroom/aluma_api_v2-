using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_decleration")]
    public class DeclerationsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryIndividualModel Schedule { get; set; }
        public string NameSurname { get; set; }
        public string SignerCapacity { get; set; }
        public string DateSigned { get; set; }
    }
}