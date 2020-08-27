using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("required_secondary_schedules_contacts")]
    public class RequiredSecondarySchedulesContactsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid RequiredSecondarySchedulesId { get; set; }
        public RequiredSecondarySchedulesModel RequiredSecondarySchedules { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MobileNumber { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public bool CompletedSchedule { get; set; }

        public RequiredSecondarySchedulesContactsModel()
        {
            CompletedSchedule = false;
        }
    }
}