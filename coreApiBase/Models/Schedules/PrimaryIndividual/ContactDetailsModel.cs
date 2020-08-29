using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_contact_details")]
    public class ContactDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryIndividualModel Schedule { get; set; }
        public string UnitNumber { get; set; }
        public string Complex { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PostalInCareName { get; set; }
        public string PA_UnitNumber { get; set; }
        public string PA_Complex { get; set; }
        public string PA_StreetNumber { get; set; }
        public string PA_StreetName { get; set; }
        public string PA_Suburb { get; set; }
        public string PA_City { get; set; }
        public string PA_PostalCode { get; set; }
        public string PA_Country { get; set; }
        public string WorkNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}