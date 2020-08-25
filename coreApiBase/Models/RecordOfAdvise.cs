using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("record_of_advise")]
    public class RecordOfAdvise : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}